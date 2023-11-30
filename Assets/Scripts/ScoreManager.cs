using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update


    public static ScoreManager instance;

    int score;
    int highscore;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("ScoreManager").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void IncrementScore()
    {
        score += 1;
    }
    public void StartScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }
    public void StopScore()
    {
        if (score > highscore)
            highscore = score;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
