using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> _pooledObjects = new List<GameObject>();
    private int _amountToPool = 5;

    [SerializeField] private List<GameObject> _targetPrefabs;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for(int i = 0; i < _targetPrefabs.Count; i++)
        {
            for(int j = 0; j < _amountToPool; j++)
            {
                GameObject objs = Instantiate(_targetPrefabs[i]);
                objs.SetActive(false);
                _pooledObjects.Add(objs);
            }           
        }
    }

    public GameObject GetPooledObjects()
    {
        for(int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        return null;
    }
}
