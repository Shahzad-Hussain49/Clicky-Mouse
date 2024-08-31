using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> tragets;
    private float spawnRate = 1.0f;
    public bool isGameOver;

    [Header("UI Components")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button gameRestartButton;
    public GameObject titleScreen;
    private int score;
    void Start()
    {
        
    }
    void Update()
    {
          
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, tragets.Count);
            Instantiate(tragets[randomIndex]);
        }
    }

    public void GameOver()
    {
        isGameOver=false;
        gameOverText.gameObject.SetActive(true);
        gameRestartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameOver = true;
        score = 0;
        spawnRate/= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
    }
}
