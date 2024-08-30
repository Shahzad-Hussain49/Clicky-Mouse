using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> tragets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    void Start()
    {
        StartCoroutine(SpawnTarget());
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
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, tragets.Count);
            Instantiate(tragets[randomIndex]);
        }
    }
}
