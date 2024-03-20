using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
public class PanelManager : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button buttonPlay = root.Q<Button>("ButtonPlay");
        Button buttonOptions = root.Q<Button>("ButtonOptions");

        buttonPlay.clicked += () => SceneManager.LoadScene("MapLayout");
    }
}
