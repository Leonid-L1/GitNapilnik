using UnityEngine;

public class MeleeCube : CubeView
{
    [SerializeField] private Melee _meleeCombatant;

    public override void SpawnCombatant(Transform container)
    {       
        //if (_meleeCombatant.GetComponent<Melee>() == null)
        //    return;

        Vector3 spawnedPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        var spawned = Instantiate(_meleeCombatant.gameObject, spawnedPosition, Quaternion.identity, container);
    }
}

    
