using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class pointCounter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score;
    public TextMeshProUGUI tmpText;

    void Start()
    {
        tmpText.text = "score: 0 \nTimer: 60s";
        show();
    }

    void Update() {
        show();
    }
//pos 247,24
    private void show(){
        if(score == 100){
            //this.transform.position = new Vector3(247,24,0);
            //this.transform.localScale = new Vector3(-75,16,0);
            tmpText.text="success!";
        }
        else if(plate.timeCount >= 60){
            tmpText.text="fail!";
        }
        else{
            int time = (int)Math.Truncate(plate.timeCount);
            tmpText.text="score: "+score.ToString()+"\nTimer: "+ time+"s";
        }
    }
}
