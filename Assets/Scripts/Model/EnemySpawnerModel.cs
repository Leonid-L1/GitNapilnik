using System;
using UnityEngine;

public class EnemySpawnerModel : Updatable
{
    private float _timeBetweenSpawn;
    private float _elapsedTime = 0;

    private GameObject _template;
    private Transform _container;

    public event Action<GameObject,Vector3,Transform> TimeToSpawn;

    public EnemySpawnerModel(float timeBetweenSpawn,GameObject template, Transform container)
    {
        _timeBetweenSpawn = timeBetweenSpawn;
        _template = template;
        _container = container;
    }

    public void Update(float deltaTime)
    {
        _elapsedTime += deltaTime;

        if(_elapsedTime >= _timeBetweenSpawn)
        {
            TimeToSpawn?.Invoke(_template,_container.position,_container);
            _elapsedTime = 0;
        }
    }
}
