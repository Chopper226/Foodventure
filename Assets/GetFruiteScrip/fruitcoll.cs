using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fruitcoll : MonoBehaviour
{
    void Start() {
        BoxCollider2D bx; 
        bx = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
     }

     void OnCollisionEnter2D(Collision2D coll) //傳入碰撞對象
    {
        if (coll.gameObject.tag == "orange")
        {
            float x = UnityEngine.Random.Range( -16.29f , 0.25f);
            coll.gameObject.transform.position = new Vector3(x,811,0);
            pointCounter.score++;
			      Debug.Log(pointCounter.score);           
        }

        if (coll.gameObject.tag == "bomb")
        {
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 813, 0);
            pointCounter.score = pointCounter.score - 2; 
            Debug.Log(pointCounter.score);           
        }

        if (coll.gameObject.tag == "peach")
        {
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 814, 0);
            pointCounter.score = pointCounter.score + 2; 
            Debug.Log(pointCounter.score);           
        }

        if (coll.gameObject.tag == "avocado")
        {
            float x = UnityEngine.Random.Range(-16.29f, 0.25f);
            coll.gameObject.transform.position = new Vector3(x, 817, 0);
            pointCounter.score = pointCounter.score + 3; 
            Debug.Log(pointCounter.score);           
        }

    }
}
