using UnityEngine;

public class RangerCube : CubeView
{
    [SerializeField] private Range _rangeCombatant;

    public override void SpawnCombatant(Transform container)
    {
        //if (_rangeCombatant.GetComponent<Range>() == null)
        //    return;

        Vector3 spawnedPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        var spawned = Instantiate(_rangeCombatant.gameObject, spawnedPosition, Quaternion.identity, container);
    }
}

