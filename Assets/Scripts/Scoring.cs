using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public static int highScore;


    void Start()
    {
        loadGame();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onCross() 
    {
        score++;

        if (score > highScore) 
        {
            highScore = score;
        }
    }

    void saveGame()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    void loadGame()
    {
        highScore = PlayerPrefs.GetInt("HiighScore");
    }
}
