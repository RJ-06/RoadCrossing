using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AdviceText : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] string[] advice;
    public static Label advText;
    [SerializeField] float rotationVal;

    void onEnable()
    {
        var uiDocument = GetComponent<UIDocument>().rootVisualElement;
        advText = uiDocument.Q<Label>("AdviceText");

        giveTip();
    }


    void giveTip() 
    {
        advText.text = advice[Random.Range(0, advice.Length)];
    }
}
