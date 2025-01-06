using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour{

    public Sprite[] cards;
    public Sprite back;
    public GameObject cardPrefab;
    
    private Vector2[] pos = new Vector2[]{
        new Vector2(0.1f, 0.1f), 
        new Vector2(0.03f, 0.03f), 
    };
    public GameObject createCard( int pos ){
        Debug.Log($"{ -5 + 10 * pos%5 }, { -5 + 10 * pos%2} , {pos}");
        Vector2 position = new( -8.7f + 1.5f * (pos%5) ,  3.5f-2.3f* (pos%2) );

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);
        newCard.SetActive(true);
        newCard.name = newCard.name.Replace( "(Clone)" , "" ).Trim();
        SpriteRenderer spriteRenderer = newCard.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = back;
        newCard.transform.localScale = new Vector3(0.1f, 0.1f, -1);
        return newCard;
    }
    
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false;  // 用來判斷卡片是否已翻轉
    private bool isFlipping = false;  // 用來判斷卡片是否正在翻轉
    private float flipSpeed = 2.0f;  // 翻轉速度
    private float currentRotation = 0f;  // 當前旋轉角度

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFlipping){
            // 進行平滑旋轉
            currentRotation = Mathf.Lerp(currentRotation, 180f, Time.deltaTime * flipSpeed);

            // 根據旋轉角度來改變顯示的圖像
            transform.rotation = Quaternion.Euler(0, currentRotation, 0);

            // 當旋轉角度接近 180 時，停止翻轉並改變圖像
            if (Mathf.Abs(currentRotation - 120f) < 1f)
            {
                FlipCard();  // 完成翻轉，顯示正面或背面
            }
            else if( Mathf.Abs(currentRotation - 180f) < 1f ){
                currentRotation = 180f;
                isFlipping = false;
            }
        }
    }

    void OnMouseDown(){
        if (!isFlipping) {
            isFlipping = true;  // 開始翻轉
        }
    }

    // 進行卡片翻轉
    public void FlipCard(){
        if (!isFlipping){
            spriteRenderer.sprite = back;  // 翻回背面
            transform.localScale = pos[0];
        }
        else{
            spriteRenderer.sprite = cards[0];  // 翻到正面
            transform.localScale = pos[1];
        }

        
        //isFlipped = !isFlipped;
    }
}
