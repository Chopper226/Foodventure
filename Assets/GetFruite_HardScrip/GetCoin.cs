using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GetCoin : MonoBehaviour
{
    bool success;
    public int coin = 0;
    public TextMeshProUGUI tmpText;
    private void show(){
        success = PlayerPrefs.GetInt("Success", 0) == 1;
        if (success){
            coin = UnityEngine.Random.Range(100,0); 
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(200, 200);
            PlayerPrefs.SetInt("Coin", coin);
            tmpText.text = "                      Win!\n            you get: " + coin.ToString() + " dollars\nPress Space to return to the main map";
        }else{
            coin = UnityEngine.Random.Range(100,0); 
            RectTransform rectTransform = tmpText.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(200, 200);
            PlayerPrefs.SetInt("Coin", -coin);
            tmpText.text = "                  Game Over!\n            you lose: -" + coin.ToString() + " dollars\nPress Space to return to the main map";
        }
    }    void Start()
    {
        tmpText.text = " ";
        show();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGameState();
            SceneManager.LoadScene("getFruite_harder", LoadSceneMode.Single);
        }
    }

    void ResetGameState()
    {
        pointCounter.score = 0;
        plate.timeCount = 0f;
        plate.gameover = false;
        orange.gameover = false;
    }

}
