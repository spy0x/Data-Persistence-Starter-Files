using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    private static string playerName;
    private static int playerBestScore;
    private static string playerNameBestScore;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public static string PlayerName { get { return playerName; } }
    public static int PlayerBestScore { get { return playerBestScore; } }
    public static string PlayerNameBestScore { get { return playerNameBestScore; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScoreData();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartPlayScene()
    {
        playerName = inputField.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void SaveBestScoreData(int points)
    {
        BestScore data = new BestScore(playerName, points);
        string dataText = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", dataText);
        LoadBestScoreData();
    }
    public static void LoadBestScoreData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            playerNameBestScore = data.Name;
            playerBestScore = data.Score;
        }

    }

}
public class BestScore
{
    public string Name;
    public int Score;
    public BestScore(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
