using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using Cinemachine;
using System.Runtime.InteropServices;

public class GameManger : MonoBehaviour
{
    private int score = 0;
    public Transform spawnPoint;
    public GameObject[] characters;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        gameOverUI.SetActive(false);
        int index = PlayerPrefs.GetInt("SelectHero",0);
        GameObject newPlayer = Instantiate(characters[index],spawnPoint.position,Quaternion.identity);
        CinemachineVirtualCamera cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cam.Follow = newPlayer.transform;
        cam.LookAt = newPlayer.transform;
    }
    // Update is called once per frame
    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; // không cho người chơi ấn phím 
        gameOverUI.SetActive(true); // hiện panel game over 
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
}
