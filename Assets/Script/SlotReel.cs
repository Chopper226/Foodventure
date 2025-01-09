using UnityEngine;

public class SlotReel : MonoBehaviour
{
    public float speed ; // 滾輪滾動速度
    public Transform[] symbols; // 滾輪上的符號
    private bool isSpinning = false;

    void Update()
    {
        if (isSpinning){

            foreach (var symbol in symbols){
                symbol.Translate(Vector3.down * speed * Time.deltaTime);

                // 循環滾輪符號
                if (symbol.position.y < -5f) {
                    symbol.position = new Vector3(symbol.position.x, 5f, symbol.position.z); 
                }
            }
        }
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    public void StopSpin(){
        isSpinning = false;

    }

}
