using UnityEngine;

public class plate : MonoBehaviour
{
    bool gameover = false;
    public static float timeCount = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = new Vector3(-15, 801, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(!gameover){
            int move = 5;
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
                move = 7;
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += new Vector3(move * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += new Vector3(-move * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.W)){
                this.transform.position += new Vector3(0, move * Time.deltaTime, 0);
            }
        }
        if(pointCounter.score == 100 || timeCount >= 60f){
            gameover = true;
        }
    }
}
