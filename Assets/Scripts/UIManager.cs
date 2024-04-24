using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    public static Label score;
    private void OnEnable()
    {
        // The UXML is already instantiated by the UIDocument component
        var uiDocument = GetComponent<UIDocument>().rootVisualElement;

        score = uiDocument.Q<Label>("ScoreVal");
    }

    public static void UpdateScore(int nScore, int hScore)
    {
        score.text = "Score: " + nScore.ToString() + "\nHigh Score: " + hScore;
    }
}
