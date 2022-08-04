using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //public Counter counter;
    // Start is called before the first frame update
    void Start()
    {
        //counter = GameObject.Find("GameManager").GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("1"))
        {
            Counter.Instance.score += 1;
        }
        else if (CompareTag("3"))
        {
            Counter.Instance.score += 3;
        }
        if (CompareTag("5"))
        {
            Counter.Instance.score += 5;
        }
        Counter.Instance.scoreText.text = "Score: " + Counter.Instance.score;
    }
}
