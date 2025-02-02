using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//to manage scenes
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    private int score;

    public bool isGameActive;

    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive) { 

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
             Instantiate(targets[index]);
            
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";

    }

    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        spawnRate /= difficulty;

        isGameActive = true;
        StartCoroutine(SpawnTarget());

        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

    }
}
