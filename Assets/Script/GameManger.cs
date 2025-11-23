
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject GamePlayUI;
    public GameObject spawner;
    public static GameManger instance;
    public bool gameStarted = false;
    public GameObject GameBackground;
    
    Vector3 originalPos;

    public GameObject player;

    int live = 2;

    int score = 0;
    public TMP_Text scoreText;
    public TMP_Text liveText;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalPos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;
        MenuUI.SetActive(false);
        GamePlayUI.SetActive(true);

        spawner.SetActive(true);
        GameBackground.SetActive(true);


    }

    public void GameOver()
    {
        player.SetActive(false);
        Invoke("RestartGame", 1.5f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if (live <= 0)
        {
            GameOver();
        }
        else
        {
            live--;
            liveText.text = "Lives: " + live;
        }
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShakeCamera()
    {
        StartCoroutine(CameraShake());
    }

    IEnumerator CameraShake()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 camPos = Random.insideUnitSphere * 0.5f;
            Camera.main.transform.position = new Vector3(camPos.x, camPos.y, originalPos.z);
            yield return null;
        }
        
        Camera.main.transform.position = originalPos;
    }
}
