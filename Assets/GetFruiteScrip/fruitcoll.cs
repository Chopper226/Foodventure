using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fruitcoll : MonoBehaviour
{
    void Start() {
				//建立碰撞器(變數的概念)
        BoxCollider2D bx; 
				//將這個腳本的物體碰撞器設給變數
        bx = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
     }

     void OnCollisionEnter2D(Collision2D coll) //傳入碰撞對象，取名coll(可自訂)
    {
				//觸發條件
        if (coll.gameObject.tag == "orange") //如果碰撞對象.的物件.的tag是apple
        {
            float x = UnityEngine.Random.Range( -16.29f , 0.25f);
            coll.gameObject.transform.position = new Vector3(x,811,0);
            pointCounter.score++;       //ScoreBoard這個class.的score全域變數
			Debug.Log(pointCounter.score);//檢查變數有沒有加成功	           
        }

    }
}
