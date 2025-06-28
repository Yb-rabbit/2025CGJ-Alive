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
    public float countdownTime = 60f; // ����ʱʱ�����룩
    public GameObject targetToDisable; // ��Ҫ�ڽ���ʱͣ�õ�GameObject

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

    // ��Mole��Hit_Mouse_N�Ƚű�����
    public void AddScore(int value)
    {
        if (!isGameActive) return;
        score += value;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "����: " + score;
    }

    // ��Ϸ����
    public void EndGame()
    {
        if (!isGameActive) return;
        isGameActive = false;
        if (targetToDisable != null)
            targetToDisable.SetActive(false);
        resultPanel.SetActive(true);
        finalScoreText.text = "���յ÷�: " + score;
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
