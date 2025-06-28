using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Hit_Mouse_N : MonoBehaviour
{
    public GameObject goodMolePrefab;  // 好地鼠预制体
    public GameObject badMolePrefab;   // 坏地鼠预制体
    public Transform[] spawnPoints;    // 地鼠出现的位置
    public float showTime = 1.0f;      // 地鼠出现的时间
    public Text scoreText;             // 显示分数的UI

    public AudioClip addScoreClip;     // 加分音效
    private AudioSource audioSource;

    public float scores = 0;           // 当前分数
    private List<GameObject> moles = new List<GameObject>();
    private float interval = 1.2f;     // 初始地鼠消失后的间隔

    void Start()
    {
        scores = 0;
        UpdateScore();
        interval = GetInterval();
        InvokeRepeating("TryShowMole", interval, interval);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void TryShowMole()//地鼠生成器
    {
        int maxMole = GetMaxMoleCount();
        if (moles.Count < maxMole)
        {
            ShowMole();
        }
    }

    void ShowMole()
    {
        int index = Random.Range(0, spawnPoints.Length);
        bool isGood = Random.value > 0.5f;
        GameObject prefab = isGood ? goodMolePrefab : badMolePrefab;
        GameObject mole = Instantiate(prefab, spawnPoints[index].position, Quaternion.identity);
        mole.GetComponent<Mole>().Init(this, isGood);
        moles.Add(mole);
        StartCoroutine(HideMoleAfterTime(mole, showTime));
    }

    System.Collections.IEnumerator HideMoleAfterTime(GameObject mole, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (mole != null)
        {
            Mole moleScript = mole.GetComponent<Mole>();
            if (moleScript != null)
                moleScript.Timeout();
        }
    }

    public void scores_add(float score)
    {
        // 只有加分时播放音效
        if (score > 0 && addScoreClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(addScoreClip);
        }

        scores += score;
        UpdateScore();

        // 动态调整生成间隔
        float newInterval = GetInterval();
        if (Mathf.Abs(newInterval - interval) > 0.01f)
        {
            interval = newInterval;
            CancelInvoke("TryShowMole");
            InvokeRepeating("TryShowMole", interval, interval);
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "分数: " + scores;
    }

    public void RemoveMole(GameObject mole)
    {
        moles.Remove(mole);
    }

    // 根据分数动态调整最大地鼠数
    int GetMaxMoleCount()
    {
        if (scores < 100) return 1;      // 分数低时只出现1只
        if (scores < 200) return 2;      // 分数中等时最多2只
        return 3;                       // 分数高时最多3只
    }

    // 根据分数动态调整生成间隔
    float GetInterval()
    {
        if (scores < -50) return 2f;
        if (scores < 100) return 1.2f;
        if (scores < 200) return 0.8f;
        return 0.5f;
    }
}
