using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPresenter : IPresenter
{
    private BlockView _view;
    private BlockModel _model;
    private List<CubeView> _cubes;

    public BlockPresenter(BlockView view, BlockModel model,  List<CubeView> cubes)
    {
        _view = view;
        _model = model;
        _cubes = cubes;
    }

    public void Enable()
    {
        _view.Dropped += OnDropped;
        _view.PlatformIsFull += OnPlatformFull;
    }

    public void Disable()
    {
        _view.Dropped -= OnDropped;
        _view.PlatformIsFull += OnPlatformFull;
    }

    private void OnDropped()
    {
        _model.SetAsDropped();
    }

    private void OnPlatformFull()
    {
        foreach (var cube in _cubes)
            cube.SpawnCombatant(_model.CombatantContainer);

        _view.Destroy();
    }
}
