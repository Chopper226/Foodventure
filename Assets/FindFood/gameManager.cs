using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    
    private int num = 5;
    private GameObject[] card;
    private int[] cardIndex;
    public CardController cardController;

    void Start(){
        card = new GameObject[num*2];
        cardIndex = new int[ num*2 ];
        initCard();
        
    }
    void Update(){

    }

    void initCard(){
        for( int i = 0 ; i < num ; i++ ){
            for( int j = 0 ; j < 2 ; j++ ){ 
                int rad = Random.Range( 0 , num*2 );
                bool check = true;
                
                while( check ){
                    if( card[rad] == null ){
                        card[rad] = cardController.createCard( rad );
                        check = false;
                    }
                    else rad = Random.Range( 0 , num*2 );
                }
                
                cardIndex[rad] = i;
            }
            
        }
    }
    


}