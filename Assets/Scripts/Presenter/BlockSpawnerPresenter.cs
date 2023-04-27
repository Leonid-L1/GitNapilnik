using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockSpawnerPresenter : IPresenter
{
    private BlockSpawnerModel _model;
    private BlockSpawnerView _view;
    private Button _respawnButton;

    private List<BlockView> _spawndedBlocks = new List<BlockView>();

    public BlockSpawnerPresenter(BlockSpawnerModel model, BlockSpawnerView view, Button respawnButton)
    {
        _model = model;
        _view = view;
        _respawnButton = respawnButton;
    }

    public void Enable()
    {
        _respawnButton.onClick.AddListener(OnRespawnButtonClick);
        _model.InstatiateRequested += OnInstantiateRequsted;
        _view.InstantiateComplete += OnInstantiateComplete;

        _model.Respawn();
    }

    public void Disable()
    {
        _respawnButton.onClick.RemoveListener(OnRespawnButtonClick);
        _model.InstatiateRequested -= OnInstantiateRequsted;
        _view.InstantiateComplete -= OnInstantiateComplete;
    }

    private void OnInstantiateComplete(BlockView spawned)
    {
        _spawndedBlocks.Add(spawned);
        spawned.OnPlatformPut += OnPlatformPutBlock;
    }

    private void OnPlatformPutBlock(BlockView block , Vector3 originPosition)
    {
        block.OnPlatformPut -= OnPlatformPutBlock;
        _spawndedBlocks.Remove(block);
        _model.SetToSpawn(originPosition);
    }

    private void OnRespawnButtonClick()
    {
        foreach (var block in _spawndedBlocks)
            block.Destroy();

        _spawndedBlocks.Clear();
        _model.Respawn();
    }
    private void OnInstantiateRequsted(Vector3 position, GameObject blockToSpawn) => _view.SpawnBlock(position, blockToSpawn);
}
