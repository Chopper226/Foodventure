using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    
    private int num = 5;
    private GameObject[] card;
    private int[] cardIndex;
    public CardController cardController;
    public Card cards;
    private List<int> flippedCards;
    private bool canPlay;

    void Start(){
        canPlay = true;
        cardIndex = new int[ num*2 ];
        initCard();
        flippedCards = new List<int>();
       // for( int i = 0 ; i<num*2 ; i++ ) cardIndex[i] = -1;
    }

    void initCard(){
        
        for( int i = 0 ; i < num ; i++ ){
            int tmpa = 0  , tmpb = 0;
            for( int j = 0 ; j < 2 ; j++ ){ 
                int rad = Random.Range( 0 , num*2 );
                bool check = true;

                while( check ){
                    if( cardIndex[rad] == -1 ){
                        cardController.createCard( rad , i );
                        check = false;
                    }
                    else rad = Random.Range( 0 , num*2 );
                }
        
                if( j == 0 ) tmpa = rad;
                else if( j == 1 ) tmpb = rad;
            }
            cardIndex[tmpa] = tmpb;
            cardIndex[tmpb] = tmpa;
            Debug.Log( $"{tmpa} , {tmpb}");
            
        }
    }

    public void checkCard( int index ){
        flippedCards.Add(index);
        
        if( flippedCards.Count == 2 ){
            canPlay = false;
            if( cardIndex[flippedCards[0]] == flippedCards[1] ) {
                StartCoroutine(matchCard(flippedCards[0] , flippedCards[1]));
            }
            else {
                StartCoroutine(resetCard(flippedCards[0] , flippedCards[1]));
            }
            flippedCards = new List<int>();
            canPlay = true;
        }
    }

    IEnumerator resetCard( int indexA , int indexB ){
        yield return new WaitForSeconds(1f); 
        cardController.reset(indexA , indexB);
    }

    IEnumerator matchCard( int indexA , int indexB ){
        yield return new WaitForSeconds(1f); 
        cardController.match(indexA , indexB);
    }

    public bool getCanPlay(){
        return canPlay;
    }


}