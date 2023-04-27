using UnityEngine;
public class EnemySpawnerPresenter : IPresenter
{   
    private EnemySpawnerModel _model;
    private SpawnerView _view;  

    public EnemySpawnerPresenter(EnemySpawnerModel model, SpawnerView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable() => _model.TimeToSpawn += OnTimeToSpawn;

    public void Disable() => _model.TimeToSpawn -= OnTimeToSpawn;


    private void OnTimeToSpawn(GameObject template, Vector3 spawnPoint, Transform container) => _view.Spawn(template, spawnPoint, container);
}
