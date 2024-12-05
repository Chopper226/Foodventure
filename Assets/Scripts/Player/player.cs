using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime != 0)
        {
            Movement();
        }
    }
    void Movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float vDirection = Input.GetAxisRaw("Vertical");

        Vector3 dirVector = Vector3.zero;
        if (hDirection < 0)
        { //move left
            dirVector = new Vector3(-1, 0);
            // transform.localPosition += (new Vector3(-1, 0, 0)) * Time.deltaTime *2;
        }
        else if (hDirection > 0)
        { //move right
            dirVector = new Vector3(1, 0);
            // transform.localPosition += (new Vector3(1, 0, 0)) * Time.deltaTime *2;
        }
        else if (vDirection > 0)
        { //move up
            dirVector = new Vector3(0, 1);
            // transform.localPosition += (new Vector3(0, 1, 0))* Time.deltaTime *2;
        }
        else if (vDirection < 0)
        { //move down
            dirVector = new Vector3(0, -1);
            // transform.localPosition += (new Vector3(0, -1, 0))* Time.deltaTime*2 ;
        }

        transform.localPosition += dirVector * Time.deltaTime * 2;
    }
}