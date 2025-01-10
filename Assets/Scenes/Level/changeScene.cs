using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class changeScene : MonoBehaviour {
    public string levelName; // 關卡名稱

    private void Update() {
        SceneManager.LoadScene(levelName);
    }

}
