using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _explosionParticles;      //ENCAPSULATION
    [SerializeField] protected int _scorePoint;     //ENCAPSULATION

    private int _lives = 1;             //ENCAPSULATION
    private float _minForce = 12.0f;    //ENCAPSULATION
    private float _maxForce = 16.0f;    //ENCAPSULATION
    private float _maxTorque = 10.0f;   //ENCAPSULATION
    private float _xPos = 4.0f;         //ENCAPSULATION
    private float _ySpawnPos = -2;      //ENCAPSULATION

    private Rigidbody _targetRb;        //ENCAPSULATION
    private GameManager _gameManager;   //ENCAPSULATION

    protected void StartSpawning()      //ABSTRACTION
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomSpawnPosition();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    private Vector3 RandomSpawnPosition()       //ABSTRACTION
    {
        return new Vector3(Random.Range(-_xPos, _xPos), _ySpawnPos);
    }

    private Vector3 RandomForce()       //ABSTRACTION
    {
        return Vector3.up * Random.Range(_minForce, _maxForce);
    }

    private float RandomTorque()        //ABSTRACTION
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    protected virtual void OnMouseDown()        //POLYMORPHISM
    {
        if(_gameManager._isGameActive)
        {
            _gameManager.UpdateScore(_scorePoint);
            Instantiate(_explosionParticles, transform.position, _explosionParticles.transform.rotation);
            Destroy(gameObject);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Good"))
        {
            if(_gameManager._lives > 0)
            {
                _gameManager.UpdateLives(_lives);
            }
        }
        Destroy(gameObject);
    }
}
