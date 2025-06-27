using UnityEngine;
using UnityEngine.UI;

public class Hit_Mouse_N : MonoBehaviour
{
    public GameObject molePrefab;      // 地鼠预制体
    public Transform[] spawnPoints;    // 地鼠出现的位置
    public float showTime = 1.0f;      // 地鼠出现的时间
    public float interval = 0.5f;      // 地鼠消失后的间隔
    public Text scoreText;             // 显示分数的UI

    public float scores = 0;           // 当前分数
    private GameObject currentMole;

    void Start()
    {
        scores = 0;
        UpdateScore();
        Invoke("ShowMole", interval);
    }

    void ShowMole()
    {
        int index = Random.Range(0, spawnPoints.Length);
        currentMole = Instantiate(molePrefab, spawnPoints[index].position, Quaternion.identity);

        // 随机生成好/坏地鼠
        bool isGood = Random.value > 0.5f;
        currentMole.GetComponent<Mole>().Init(this, isGood);

        Invoke("HideMole", showTime);
    }

    void HideMole()
    {
        if (currentMole != null)
        {
            Destroy(currentMole);
        }
        Invoke("ShowMole", interval);
    }

    // 被Mole调用，分数变化
    public void scores_add(float score)
    {
        scores += score;
        UpdateScore();
        if (currentMole != null)
        {
            Destroy(currentMole);
        }
        CancelInvoke("HideMole");
        Invoke("ShowMole", interval);
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "分数: " + scores;
    }
}
