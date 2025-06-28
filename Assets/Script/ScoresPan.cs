using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoresPan : MonoBehaviour
{
    public static ScoresPan Instance { get; private set; }

    public Text scoreText;
    public GameObject resultPanel;
    public Text finalScoreText;
    public Button replayButton;
    public Button quitButton;
    public float countdownTime = 60f; // 倒计时时长（秒）
    public GameObject targetToDisable; // 需要在结束时停用的GameObject

    private int score = 0;
    private float timer;
    private bool isGameActive = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = countdownTime;
        resultPanel.SetActive(false);
        replayButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        UpdateScoreText();
    }

    void Update()
    {
        if (isGameActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 0f;
                EndGame();
            }
        }
    }

    // 供Mole、Hit_Mouse_N等脚本调用
    public void AddScore(int value)
    {
        if (!isGameActive) return;
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "分数: " + score;
    }

    // 游戏结束
    public void EndGame()
    {
        if (!isGameActive) return;
        isGameActive = false;
        if (targetToDisable != null)
            targetToDisable.SetActive(false);
        resultPanel.SetActive(true);
        finalScoreText.text = "最终得分: " + score;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
