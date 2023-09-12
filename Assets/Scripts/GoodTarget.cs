using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodTarget : Target
{
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartSpawning();        //INHERITANCE
    }

    protected override void OnMouseDown()       //POLYMORPHISM
    {
        if (_gameManager._isGameActive)
        {
            _gameManager.UpdateScore(_scorePoint);
            Instantiate(_explosionParticles, transform.position, _explosionParticles.transform.rotation);
            Destroy(gameObject);
        }
    }
}
