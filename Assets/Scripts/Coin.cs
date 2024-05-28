using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    float starty;

    void Start()
    {
        starty = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(1, 0, 0), 30f * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() == null)
            return;

        Scoring.onScore();

        this.gameObject.gameObject.SetActive(false);

    }
}
