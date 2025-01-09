using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int score = 0;
    public bool isEnd = false;
    public TextMeshProUGUI resultText;
    void Start()
    {
        score = 0; // 初始化分數
    }

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = $"Score: {score}"; // 更新分數
        if (isEnd && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"按下'E'返回主地圖");
            SceneManager.LoadScene(0);
            // SceneManager.LoadScene("Sample Scene"); // 切換場景
        }
    }

    public void AddScore(int score)
    {
        this.score += score; // 增加分數
        if(this.score >= 5){
            resultText.gameObject.SetActive(true);
            resultText.text = "You Win!";
            isEnd = true;
        }else if(this.score <= -3){
            resultText.gameObject.SetActive(true);
            resultText.text = "You Lose!";
            isEnd = true;
        }
        
    }

    


}
