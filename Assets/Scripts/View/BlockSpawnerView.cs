using System;
using UnityEngine;

public class BlockSpawnerView : MonoBehaviour
{
    [SerializeField] private SpawnerView _spawner;
    [SerializeField] private PlatformView _platform;
    [SerializeField] private Transform _combatantContainer;

    public event Action<BlockView> InstantiateComplete;

    public void SpawnBlock(Vector3 position, GameObject blockToSpawn)
    {       
        var spawned = _spawner.Spawn(blockToSpawn, position, transform);
        spawned.GetComponent<BlockSetup>().Init(_platform,_combatantContainer);
        InstantiateComplete?.Invoke(spawned.GetComponent<BlockView>());
    }
}
