using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;    //ENCAPSULATION
    [SerializeField] private TextMeshProUGUI _livesText;    //ENCAPSULATION
    [SerializeField] private TextMeshProUGUI _gameOverText; //ENCAPSULATION
    [SerializeField] private Button _restartButton;         //ENCAPSULATION
    [SerializeField] private GameObject _titleScreen;       //ENCAPSULATION

    [HideInInspector] public bool _isGameActive;
    [HideInInspector] public int _lives = 3;

    private int _score;
    private float _spawnRate = 1.0f;

    public void StartGame(int difficulty)
    {
        _titleScreen.gameObject.SetActive(false);
        _isGameActive = true;
        _spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(0);
    }

    IEnumerator SpawnTarget()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            ObjectPool.instance.GetPooledObjects();                        
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int currentLives)
    {
        _lives -= currentLives;
        _livesText.text = "Lives: " + _lives;

        if(_lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        _isGameActive = false;
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
