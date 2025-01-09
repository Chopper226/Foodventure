using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slotController : MonoBehaviour
{
    public SlotReel[] reels; // 連結所有滾輪
    public float spinDuration = 2f; // 滾輪旋轉的時間

    public void StartSpin(){
        StartCoroutine(SpinReels());
    }

    private IEnumerator SpinReels(){
        foreach (var reel in reels)
        {
            reel.StartSpin(); // 啟動滾輪
            yield return new WaitForSeconds(0.5f); // 每個滾輪延遲啟動
        }

        yield return new WaitForSeconds(spinDuration); // 等待旋轉完成

        foreach (var reel in reels){
            reel.StopSpin(); // 停止滾輪
        }
    }
}
