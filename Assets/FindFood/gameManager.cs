using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    
    private int num = 5;
    private GameObject[] card;
    private int[] cardIndex;
    public CardController cardController;
    public Card cards;
    private List<int> flippedCards;

    void Start(){
        card = new GameObject[num*2];
        cardIndex = new int[ num*2 ];
        initCard();
        flippedCards = new List<int>();
        
    }

    void initCard(){
        
        for( int i = 0 ; i < num ; i++ ){
            int tmpa = 0  , tmpb = 0;
            for( int j = 0 ; j < 2 ; j++ ){ 
                int rad = Random.Range( 0 , num*2 );
                bool check = true;

                while( check ){
                    if( card[rad] == null ){
                        card[rad] = cardController.createCard( rad , i , j );
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
            if( cardIndex[flippedCards[0]] == flippedCards[1] ) cardController.match(flippedCards[0] , flippedCards[1] );
            //else resetCard();
            flippedCards = new List<int>();
        }

    }


}