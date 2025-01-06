using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour{
    public Sprite[] cards;
    public Sprite back;
    
    private int index;
    private bool isFlipped = false;  // 用來判斷卡片是否已翻轉
    private bool isFlipping = false;  // 用來判斷卡片是否正在翻轉
    private float flipSpeed = 2.0f;  // 翻轉速度
    private float currentRotation = 0f;  // 當前旋轉角度

    private bool isMatching = false;
    private float shrinkSpeed = 2f; // 縮放速度
    public GameManager gameManager;
    SpriteRenderer spriteRenderer;
    private Vector2[] pos = new Vector2[]{
        new Vector2(0.1f, 0.1f), 
        new Vector2(0.03f, 0.03f), 
    };

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = back;
    }

    void Update(){
        if (isFlipping){
            currentRotation = Mathf.Lerp(currentRotation, 180f, Time.deltaTime * flipSpeed);
            transform.rotation = Quaternion.Euler(0, currentRotation, 0);

            if (Mathf.Abs(currentRotation - 120f) < 1f){
                FlipCard(); 
            }
            else if( Mathf.Abs(currentRotation - 180f) < 1f ){
                currentRotation = 180f;
                isFlipping = false;
            }
        }

        if (isMatching){
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * shrinkSpeed);
            if (transform.localScale.magnitude < 0.01f) Destroy(gameObject); // 銷毀物件
        }
    }

    void OnMouseDown(){
        if (!isFlipping) isFlipping = true;
        Debug.Log($"{index}");
        gameManager.checkCard(index);
    }

    public void FlipCard(){
        if (!isFlipping){
            spriteRenderer.sprite = back; 
            transform.localScale = pos[0];
        }
        else{
            spriteRenderer.sprite = cards[0];
            transform.localScale = pos[1];
        }

    }

    public void setIndex( int index ){
        this.index = index;
    }

    public void setIsMatching( bool isMatching ){
        this.isMatching = isMatching;
    }
}