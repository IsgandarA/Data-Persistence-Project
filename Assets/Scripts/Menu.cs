using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class Menu : MonoBehaviour
{
    
    public static Menu Instance;

    [SerializeField] Button start;
    [SerializeField] Button b2;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI user;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }

        //IEnumerator Scene()
        //{
        //    yield return new WaitForSeconds(3);
        //    SceneManager.LoadScene(1);
        //}
    }
