using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
    private Button _buttons;
    private GameManager _gameManager;

    [SerializeField] private int _difficulty;

    // Start is called before the first frame update
    void Start()
    {
        _buttons = GetComponent<Button>();
        _buttons.onClick.AddListener(SetDifficulty);

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(_difficulty);
    }
}
