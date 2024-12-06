using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

public class orange2 : MonoBehaviour
{
    public float timer = -1f;
    bool gameover = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float x = UnityEngine.Random.Range( -82.99f , -66.83f);
        this.transform.position = new Vector3(x,22,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameover){
            timer += Time.deltaTime;

            if (timer >= 0.01f)
            {
                timer = 0f;
                this.transform.position -= new Vector3(0,0.05f,0);
            }

            if(this.transform.position.y < 10.5f){
                float x = UnityEngine.Random.Range( -82.99f , -66.83f);
                this.transform.position = new Vector3(x,22,0);
            }
        }

        if(pointCounter.score == 100 || plate.timeCount >= 60f){
            timer = 0f;
            gameover = true;
        }
    }
}