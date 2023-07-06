using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    [SerializeField] private int _enemyHealth;
    [SerializeField] private int _enemyAttack;
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _timeBetweenEnemySpawn;
    [SerializeField] private int _maxWariorUpgradeLevel;
    [SerializeField] private List<int> _upgradeCheckPoints;

    public int PlayerHealth => _playerHealth;
    public int EnemyHealth => _enemyHealth;
    public int EnemiesCount => _enemiesCount;
    public float TimeBetweenEnemySpawn => _timeBetweenEnemySpawn;
    public int MaxWariorUpgradeLevel => _maxWariorUpgradeLevel;
    public List<int> UpgradeCheckPoints => _upgradeCheckPoints;
}
