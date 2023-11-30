using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GameStart()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.StartScore();
    }

    void GameOver()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        BallController.instance.GameOver();
    }

    public void Reset()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
