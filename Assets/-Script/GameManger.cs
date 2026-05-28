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
    [SerializeField] protected TextMeshProUGUI scoreText;
    [SerializeField] protected GameObject gameOverUI;
    [SerializeField] protected GameObject[] characters;
    [SerializeField] protected Transform spawnPoint;
    protected int score = 0;
    public bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateScore();
        this.gameOverUI.SetActive(false);
        this.ChooseCharacter();
    }
    protected virtual void ChooseCharacter()
    {
        int index = PlayerPrefs.GetInt("SelectHero",0);
        GameObject newPlayer = Instantiate(characters[index],spawnPoint.position,Quaternion.identity);
        this.SetCamera(newPlayer);
    }
    protected virtual void SetCamera(GameObject newPlayer)
    {
        CinemachineVirtualCamera cam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        cam.Follow = newPlayer.transform;
        cam.LookAt = newPlayer.transform;
    }
    // Update is called once per frame
    public void AddScore(int points)
    {
        if (!this.isGameOver)
        {
            score += points;
            this.UpdateScore();
        }
    }
    protected virtual void UpdateScore()
    {
        this.scoreText.text = score.ToString();
    }
    public virtual void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; // không cho người chơi ấn phím 
        gameOverUI.SetActive(true); // hiện panel game over 
    }
    public virtual void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public virtual bool IsGameOver()
    {
        return isGameOver;
    }
}
