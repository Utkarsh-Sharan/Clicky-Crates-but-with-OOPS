using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadTarget : Target, IPoolable
{
    public void OnObjectPool()
    {        
        StartSpawning();        //INHERITANCE
    }

    protected override void OnMouseDown()       //POLYMORPHISM
    {
        if (_gameManager._isGameActive)
        {
            _gameManager.UpdateScore(_scorePoint);
            Instantiate(_explosionParticles, transform.position, _explosionParticles.transform.rotation);
            gameObject.SetActive(false);
        }
    }
}
