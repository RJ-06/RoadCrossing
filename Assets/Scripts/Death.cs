using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private int finScore;
    [SerializeField] string[] deathMessages;
    private string deathTip;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Car>() != null) 
        {

            Time.timeScale = 0;
            finScore = Scoring.score;
            deathTip = deathMessages[0];
        }
    }

    public string getDeathTip() 
    {
        return deathTip;
    }
}
