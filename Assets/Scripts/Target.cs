using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticles;
    [SerializeField] private int _scorePoint;

    private int _lives = 1;
    private float _minForce = 12.0f;
    private float _maxForce = 16.0f;
    private float _maxTorque = 10.0f;
    private float _xPos = 4.0f;
    private float _ySpawnPos = -2;

    private Rigidbody _targetRb;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        _targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minForce, _maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_xPos, _xPos), _ySpawnPos);
    }

    private void OnMouseDown()
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
