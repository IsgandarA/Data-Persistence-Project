using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public bool gameOver;
    public bool gameOn;
    [SerializeField] Button restart;
    [SerializeField] Button start;
    [SerializeField] TextMeshProUGUI prediction;
    [SerializeField] Button plus5;
    [SerializeField] Button minus5;
    [SerializeField] TextMeshProUGUI ballCountText;
    public TextMeshProUGUI scoreText;
    public Slider power;
    public int score = 0;
    public int predictionN = 0;
    [SerializeField] GameObject sphere;
    [SerializeField] Camera cam;
    private int ballCount;
    public bool thisShot;

    private void Start()
    {

        ballCountText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        score = 0;
        ballCount = 0;
        prediction.text = "Prediction: " + 0;
        power.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        cam = Camera.main;
    }
    private void Update()
    {
        if (ballCount == 10)
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
        start.gameObject.SetActive(false);
        plus5.gameObject.SetActive(false);
        minus5.gameObject.SetActive(false);
        power.gameObject.SetActive(true);
        StartCoroutine("Balls");
    }
    public void PredictionUp()
    {
        predictionN+=5;
        prediction.SetText("Prediction: " + predictionN);
    }
    public void PredictionDown()
    {
        predictionN-=5;
        prediction.SetText("Prediction: " + predictionN);
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
                thisShot = false;
                Instantiate(sphere, new Vector3(17, 6, 0), transform.rotation);
                ballCount += 1;
                ballCountText.text = "Balls: " + (11 - ballCount);
                yield return new WaitUntil(() => thisShot == true);
                yield return new WaitForSeconds(1);
            }
        }
        
    }
    void GameOver()
    {
        gameOver = true;
        restart.gameObject.SetActive(true);
    }

}
