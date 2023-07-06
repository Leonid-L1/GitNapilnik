public class WarriorSpawnerPresenter
{
    private WarriorSpawnerView _view;
    private WarriorSpawnerModel _model;

    public WarriorSpawnerPresenter(WarriorSpawnerView view, WarriorSpawnerModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.WarriorNewLevelSet += _model.SetNewLevel;
        _view.SpawnRequired += _model.OnSpawnRequired;
        _model.WarriorSetToSpawn += _view.SpawnWarrior;
    }

    public void Disable()
    {
        _view.WarriorNewLevelSet -= _model.SetNewLevel;
        _view.SpawnRequired -= _model.OnSpawnRequired;
        _model.WarriorSetToSpawn -= _view.SpawnWarrior;
    }
}


