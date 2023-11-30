using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI menuScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject menuPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    void Start()
    {
       
        menuPanel.SetActive(true);
        menuScoreText.text = "High Score: " + ScoreManager.instance.GetHighScore().ToString();
        gameOverPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        menuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        //SceneManager.LoadScene();
        //does everything needed when loading the game. (e.g. activating/deactivating texts)

    }

    public void GameOver()
    {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
        highScoreText.text = ScoreManager.instance.GetHighScore().ToString();
        gameOverPanel.SetActive(true);
        //does anything when the game is over (e.g. activate game over Panel)   

    }

    public void Reset()
    {
        GameStart();
    }
}
