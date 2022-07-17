using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Counter counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("GameManager").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("1"))
        {
            counter.score += 1;
        }
        else if (CompareTag("3"))
        {
            counter.score += 3;
        }
        if (CompareTag("5"))
        {
            counter.score += 5;
        }
        counter.scoreText.text = "Score: " + counter.score;
    }
}
