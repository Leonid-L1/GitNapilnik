using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WarriorSpawnerView : MonoBehaviour
{
    private AudioSource _spawnSound;

    public event Action<AllyCombatant, int> WarriorNewLevelSet;
    public event Action<int,int> SpawnRequired;

    private void Start() => _spawnSound = GetComponent<AudioSource>();
    
    public void SetWarriorLevel(AllyCombatant warriorType, int newLevel) => WarriorNewLevelSet?.Invoke(warriorType, newLevel);

    public void SetAsSpawnRequired(int meleeCount, int rangeCount) => SpawnRequired?.Invoke(meleeCount,rangeCount);

    public void SpawnWarrior(GameObject warriorToSpawn)
    {   
        _spawnSound.Play();
        Instantiate(warriorToSpawn, transform.position, Quaternion.identity, transform);
    }
}
