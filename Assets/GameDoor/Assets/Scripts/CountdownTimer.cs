using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 用來顯示倒計時的 UI 元件
    public GameObject GameOverPanel; // 顯示失敗訊息的面板
    private float timeLeft = 30f;   // 倒計時的時間（秒）

    private bool isGameActive = true; // 遊戲是否正在進行

    void Start()
    {
        GameOverPanel.SetActive(false); // 隱藏失敗面板
        UpdateTimerUI(); // 初始化倒計時顯示
    }

    void Update()
    {
        if (isGameActive)
        {
            // 減少剩餘時間
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                timeLeft = 0; // 確保時間不為負數
                GameOver(false);   // 倒計時結束時處理遊戲失敗
            }

            UpdateTimerUI(); // 更新倒計時 UI
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"按下'E'返回主地圖");
            SceneManager.LoadScene(0);
            // SceneManager.LoadScene("Sample Scene"); // 切換場景
        }
    }

    // 更新倒計時 UI
    void UpdateTimerUI()
    {
        timerText.text = $"Time left : {Mathf.Ceil(timeLeft)} s";
    }

    // 處理遊戲結束
    public void GameOver(bool isWin = false)
    {
        isGameActive = false; // 停止遊戲
        if(isWin){
            GameOverPanel.GetComponent<TextMeshProUGUI>().text = "You Win!";

        }else{
            GameOverPanel.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
        GameOverPanel.SetActive(true); // 顯示失敗訊息
        Debug.Log("遊戲失敗！");
    }
}
