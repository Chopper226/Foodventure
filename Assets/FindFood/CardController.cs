using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour{

   
    public GameObject cardPrefab;
    private List<GameObject> list = new List<GameObject>();
    public GameObject createCard( int pos , int i , int j){
        Debug.Log($"{ -5 + 10 * (i%5) }, { -5 + 10 * pos%2} , {pos}");
        Vector2 position = new( -8.7f + 1.5f * i ,  3.5f-2.3f* j) ;

        GameObject newCard = Instantiate(cardPrefab, position, Quaternion.identity);
        newCard.SetActive(true);
        newCard.name = newCard.name.Replace( "(Clone)" , "" ).Trim();
        newCard.transform.localScale = new Vector3(0.1f, 0.1f, -1);

        Card cardScript = newCard.GetComponent<Card>();
        cardScript.setIndex(pos);

        list.Add(newCard);
        return newCard;
    }

    public void match( int indexA , int indexB ){
        Card cardScript = list[indexA].GetComponent<Card>();
        cardScript.setIsMatching(true);
        cardScript = list[indexB].GetComponent<Card>();
        cardScript.setIsMatching(true);
    }

}
