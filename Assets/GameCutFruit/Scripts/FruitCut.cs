using UnityEngine;

public class Cut : MonoBehaviour
{
    public GameObject leftHalfPrefab;  // 左半水果 3D 模型
    public GameObject rightHalfPrefab; // 右半水果 3D 模型
    private Score score;
    public float forceMagnitude = 5f; // 切割後的力大小

    void Start()
    {
        score = FindFirstObjectByType<Score>(); // 獲取 Score 組件
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blade")) // 檢測刀刃碰撞
        {
            SliceFruit(); // 切割水果
            score.AddScore(1); // 增加分數
        }
    }

    void SliceFruit()
    {
        // 獲取當前水果的位置和旋轉
        Vector3 fruitPosition = transform.position;
        Quaternion fruitRotation = transform.rotation;

        // 生成左半水果
        GameObject leftHalf = Instantiate(leftHalfPrefab, fruitPosition, fruitRotation);
        Rigidbody leftRb = leftHalf.GetComponent<Rigidbody>();
        if (leftRb != null)
        {
            // 左半向左上方移動
            Vector3 leftForce = new Vector3(-1f, 1f, 0f) * forceMagnitude;
            leftRb.AddForce(leftForce, ForceMode.Impulse);
            leftRb.AddTorque(Random.insideUnitSphere * 200f); // 添加隨機旋轉
        }

        // 生成右半水果
        GameObject rightHalf = Instantiate(rightHalfPrefab, fruitPosition, fruitRotation);
        Rigidbody rightRb = rightHalf.GetComponent<Rigidbody>();
        if (rightRb != null)
        {
            // 右半向右上方移動
            Vector3 rightForce = new Vector3(1f, 1f, 0f) * forceMagnitude;
            rightRb.AddForce(rightForce, ForceMode.Impulse);
            rightRb.AddTorque(Random.insideUnitSphere * 200f); // 添加隨機旋轉
        }

        // 刪除原始水果物件
        Destroy(gameObject);
    }
}
