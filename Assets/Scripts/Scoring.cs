using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public static int highScore;


    void Start()
    {
        loadGame();
        
        score = 0;
        Debug.Log("Updating Score");
        UIManager.UpdateScore(score, highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void onScore() 
    {
        score++;
        if (score > highScore) 
        {
            highScore = score;
            saveGame();
        }
        UIManager.UpdateScore(score, highScore);
    }

    static void saveGame()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    static void loadGame()
    {
        Debug.Log("this happened");
        try
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        catch
        {
            highScore = 0;
            Debug.Log("Lame!");
        }
    }
}
