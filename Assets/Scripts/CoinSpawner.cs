using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _template;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_spawnPoints.Length > 0)
        {
            Vector3 spawnAt = PickSpawnPoint();

            var coin = Instantiate(_template, spawnAt, Quaternion.identity);
            coin.Init(Spawn);
        }
    }

    private Vector3 PickSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }
}
