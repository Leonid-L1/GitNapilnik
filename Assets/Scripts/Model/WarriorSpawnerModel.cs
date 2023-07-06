using System;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSpawnerModel
{
    private List<GameObject> _meleeWarriorsByLevel;
    private List<GameObject> _rangeWarriorsByLevel;

    private int _currentMeleeLevel = 0;
    private int _currentRangeLevel = 0;

    public event Action<GameObject> WarriorSetToSpawn;
    
    public WarriorSpawnerModel(List<GameObject> meleeWarriorsByLevel, List<GameObject> rangeWarriorsByLevel)
    {
        _meleeWarriorsByLevel = meleeWarriorsByLevel;
        _rangeWarriorsByLevel = rangeWarriorsByLevel;
    }

    public void OnSpawnRequired(int meleeWarriorsToSpawn, int rangeWarriorsToSpawn)
    {
        for (int i = 0; i < meleeWarriorsToSpawn; i++)
            WarriorSetToSpawn?.Invoke(_meleeWarriorsByLevel[_currentMeleeLevel]);

        for (int i = 0; i < rangeWarriorsToSpawn; i++)
            WarriorSetToSpawn?.Invoke(_rangeWarriorsByLevel[_currentRangeLevel]);
    }

    public void SetNewLevel(AllyCombatant warriorType, int newLevel)
    {
        if (warriorType.gameObject.GetComponent<Melee>() != null)
            _currentMeleeLevel = newLevel;

        if (warriorType.gameObject.GetComponent<Range>() != null)
            _currentRangeLevel = newLevel;
    }
        
}
