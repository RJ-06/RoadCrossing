using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class PanelManager : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        UnityEngine.UIElements.Button buttonPlay = root.Q<UnityEngine.UIElements.Button>("ButtonPlay");
        UnityEngine.UIElements.Button buttonOptions = root.Q<UnityEngine.UIElements.Button>("ButtonOptions");

        buttonPlay.clicked += () => SceneManager.LoadScene("Level1Layout");
    }
}
