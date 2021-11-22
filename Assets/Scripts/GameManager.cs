using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    private static string playerName;
    private static int playerBestScore;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public static string PlayerName { get { return playerName; } set { playerName = value; } }
    public static int PlayerBestScore { get { return playerBestScore; } set { playerBestScore = value; } }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartPlayScene()
    {
        playerName = inputField.text;
        Debug.Log($"El nombre del player es: {playerName}");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
