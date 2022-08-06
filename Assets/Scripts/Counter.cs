using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Counter : MonoBehaviour
{
    public static Counter Instance { get; set; }

    public bool gameOver;
    public bool gameOn;
    [SerializeField] Button restart;
    [SerializeField] TextMeshProUGUI ballCountText;
    public TextMeshProUGUI scoreText;
    public Slider power;
    public float powerScore;
    public int score = 0;
    [SerializeField] GameObject sphere;
    [SerializeField] Camera cam;
    private int ballCount;
    //public bool thisShot;
    public float balll;
    private GameObject sphere1;
    private Ball ballScript;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        power.gameObject.SetActive(true);
        
        Instance = this;

    }
    private void Start()
    {
        
        ballCountText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        score = 0;
        ballCount = 0;
        //power.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        cam = Camera.main;
        StartGame();
    }
    private void Update()
    {
        if (ballScript != null)
        {
            //powerScore = ballScript.shotPower;
            power.value = powerScore;
        }
        if (ballCount == 11)
        {
            GameOver();
        }
    }

    public void StartGame()
    {
        gameOn = true;
        scoreText.gameObject.SetActive(true);
        ballCountText.gameObject.SetActive(true);
        ballCountText.text = "Balls: 10";
        //power.gameObject.SetActive(true);
        StartCoroutine("Balls");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator Balls()
    {
        {
            while (!gameOver & ballCount < 11)
            {
                sphere1 = (GameObject)GameObject.Instantiate(sphere, new Vector3(0, 8, -17), transform.rotation);
                ballScript = sphere1.GetComponent<Ball>();
                ballCount += 1;
                ballCountText.text = "Balls: " + (11 - ballCount);
                yield return new WaitUntil(() => ballScript.shot == true);
                yield return new WaitForSeconds(1);

            }
        }
        
    }
    void GameOver()
    {
        gameOver = true;
        if (score > Menu.Instance.highScoreInt)
        {
            Menu.Instance.highScoreInt = score;
            Menu.Instance.playerScoreHist[Menu.Instance.playerN] = Menu.Instance.highScoreInt;
            Menu.Instance.SaveScore();

        }
        Menu.Instance.highScore.text = "High score:" + Menu.Instance.highScoreInt.ToString();
        Debug.Log(Menu.Instance.playerScoreHist.Keys);
        restart.gameObject.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Menu.Instance.start.gameObject.SetActive(true);
    }

}
