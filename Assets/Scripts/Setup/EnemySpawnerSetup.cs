using UnityEngine;

[RequireComponent(typeof(SpawnerView))]
public class EnemySpawnerSetup : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Enemy _template;
    [SerializeField] private float _timeBetweenSpawn;

    private SpawnerView _view;
    private EnemySpawnerModel _model;
    private EnemySpawnerPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<SpawnerView>();
        _model = new EnemySpawnerModel(_timeBetweenSpawn, _template.gameObject, transform);
        _timer.AddUpdatable(_model);
        _presenter = new EnemySpawnerPresenter(_model, _view);
    }

    private void OnEnable() => _presenter.Enable();

    private void OnDisable() => _presenter.Disable();
}
