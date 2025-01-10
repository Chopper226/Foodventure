using UnityEngine;
using System.Collections;

public class SlotController : MonoBehaviour
{
    public SlotReel[] reels; // 連結所有滾輪
    public float spinTime = 0f; // 滾輪旋轉的時間
    bool isSpinning = false;

    public void StartSpin()
    {
        StartCoroutine(SpinReels());
    } 
    void Update(){
        if(isSpinning){
            spinTime += Time.deltaTime;
        }
        if (spinTime >= 10f)
        {
            StopSpin();
            // 确保滚轮回到初始位置（y 间隔 1.81f）
            float k2 = (reels[2].transform.position.y - reels[0].transform.position.y) % 1.81f;
            if (k2 != 0)
            {
                reels[2].transform.position -= new Vector3(0, k2 - 0.155f, 0);
                reels[3].transform.position -= new Vector3(0, k2 - 0.155f, 0);
            }

            float k3 = (reels[4].transform.position.y - reels[0].transform.position.y) % 1.81f;
            if (k3 != 0)
            {
                reels[4].transform.position -= new Vector3(0, k3 + 0.1f, 0);
                reels[5].transform.position -= new Vector3(0, k3 + 0.1f, 0);
            }

            // 对齐回原始位置
            //this.transform.position = initialPosition;
            spinTime = 0f;
            isSpinning = false;
        }
    }

    private IEnumerator SpinReels()
    {
        spinTime += Time.deltaTime;
        int i = 0;
        
        // 兩組交替啟動滾輪
        foreach (var reel in reels)
        {
            i++;
            reel.StartSpin();
            if (i % 2 == 0)
            {
                yield return new WaitForSeconds(0.5f); // 停顿 0.9 秒后再启动下一组
            }
            isSpinning = true;
        }
    }

    public void StopSpin()
    {
        foreach (var reel in reels)
        {
            reel.StopSpin();
        }
    }
}
