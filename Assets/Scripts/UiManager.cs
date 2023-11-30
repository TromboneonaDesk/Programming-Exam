using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro highScoreText;
    [SerializeField] private GameObject MenuPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        MenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        //SceneManager.LoadScene();
        //does everything needed when loading the game. (e.g. activating/deactivating texts)

    }

    public void GameOver()
    {
        scoreText.text = ScoreManager.instance.GetScore().ToString();
        scoreText.text = ScoreManager.instance.GetHighScore().ToString();
        gameOverPanel.SetActive(true);
        //does anything when the game is over (e.g. activate game over Panel)   

    }

    public void Reset()
    {
        GameStart();
    }
}
