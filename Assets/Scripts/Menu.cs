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
    public Dictionary<string, int> playerScoreHist = new Dictionary<string, int>();
    public static Menu Instance;
    public int highScoreInt;
    public Button start;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI user;
    public string playerN;
    private bool nameInped;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Application.persistentDataPath + "/savefile.json");
        LoadScore();

        //StartCoroutine("Scene");
        start.gameObject.SetActive(false);
        user.gameObject.SetActive(false);
        playerName.text = "Player: ";
    }
    private void Awake()
    {
        
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (!nameInped)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // has backspace/delete been pressed?
                {
                    if (playerName.text.Length != 8)
                    {
                        playerName.text = playerName.text.Substring(0, playerName.text.Length - 1);

                    }
                
                }
                else if ((c == '\n') || (c == '\r')) // enter/return
                {
                    nameInped = true;
                    playerN = playerName.text.Substring(9, playerName.text.Length-9);
                    if (playerScoreHist.ContainsKey(playerN))
                    {
                        highScoreInt = playerScoreHist[playerN];
                    }
                    else
                    {
                        playerScoreHist.Add(playerN, 0);
                    }
                    highScore.text = "High score: "+ playerScoreHist[playerN].ToString();
                    Next();
                }
                else
                {
                    playerName.text = playerName.text + c;
                }
            }
        }
    }
    public void Next()
    {
        user.text = playerName.text;
        playerName.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        user.gameObject.SetActive(true);
    }
    public void StartGame()
    {

        SceneManager.LoadScene(1);
        start.gameObject.SetActive(false);
        //Counter.Instance.user.text = user.text;
        //Counter.Instance.StartGame();
    }
    [Serializable]
    class SaveData
    {
        public List<string> playersList;
        public List<int> playerScores;
    }
    public void SaveScore()
    {
        SaveData updPlayers = new SaveData();
        updPlayers.playersList = new List<String>(playerScoreHist.Keys);
        updPlayers.playerScores = new List<int>(playerScoreHist.Values);
        string json = JsonUtility.ToJson(updPlayers);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData updPlayers = JsonUtility.FromJson<SaveData>(json);
            foreach (string player in updPlayers.playersList)
            {
                playerScoreHist.Add(player, updPlayers.playerScores[updPlayers.playersList.IndexOf(player)]);
            }

        }
    }
    //IEnumerator Scene()
    //{
    //    yield return new WaitForSeconds(3);
    //    SceneManager.LoadScene(1);
    //}
}
