using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour{

   
    public GameObject cardPrefab;
    private List<GameObject> list = new List<GameObject>();
    private int[] num = new int[ 10 ];
    public GameObject createCard( int pos , int i){
        Vector2 position = new( -8.7f + 1.5f * (pos%5) ,  3.5f-2.3f* (pos%2) );

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);
        newCard.SetActive(true);
        newCard.name = newCard.name.Replace( "(Clone)" , "" ).Trim();
        newCard.transform.localScale = new Vector3(0.1f, 0.1f, -1);

        Card cardScript = newCard.GetComponent<Card>();
        cardScript.setIndex(pos);
        cardScript.setImage(i);
        num[pos] = list.Count;
        list.Add(newCard);
        
        return newCard;
    }

    public void match( int indexA , int indexB ){
        Card cardScript = list[num[indexA]].GetComponent<Card>();
        cardScript.setIsMatching(true);
        cardScript = list[num[indexB]].GetComponent<Card>();
        cardScript.setIsMatching(true);
    }

    public void reset( int indexA , int indexB ){
        Card cardScript = list[num[indexA]].GetComponent<Card>();
        cardScript.setIsFlipping(true);
        cardScript = list[num[indexB]].GetComponent<Card>();
        cardScript.setIsFlipping(true);
    }

}
