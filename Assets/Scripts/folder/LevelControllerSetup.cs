using UnityEngine;

[RequireComponent(typeof(LevelSettings))]
[RequireComponent(typeof(LevelControllerView))]
public class LevelControllerSetup : MonoBehaviour
{
    [SerializeField] private int _currentLevelNumber;

    [SerializeField] private CastleHealthSetup _playerHealth;
    [SerializeField] private EnemyProgressionBarSetup _enemyProgression;
    [SerializeField] private EnemySpawnerSetup _enemySpawner;
    [SerializeField] private UpgradeWarriorSetup _upgradeMelee;
    [SerializeField] private UpgradeWarriorSetup _upgradeRange;
    [SerializeField] private LosePanelSetup _losePanel;
    [SerializeField] private WinPanelSetup _winPanel;
    [SerializeField] private PausePanelSetup _pausePanel;

    private LevelSettings _settings;

    // модель и все остальное вероятно не нужны
    private LevelControllerModel _model;
    private LevelControllerView _view;
    private LevelControllerPresenter _presenter;
    // модель и все остальное вероятно не нужны
    private void Awake()
    {
        int nextLevelIndex = _currentLevelNumber + 1;

        _settings = GetComponent<LevelSettings>();
        _view = GetComponent<LevelControllerView>();

        _losePanel.Init(_currentLevelNumber);
        _playerHealth.Init(_settings.PlayerHealth, _losePanel.GetComponent<LosePanelView>());
        _winPanel.Init(nextLevelIndex, _settings.PlayerHealth,_playerHealth.GetComponent<CastleHealthView>());
        _pausePanel.Init(_currentLevelNumber);
        _enemyProgression.Init(_settings.EnemiesCount, _settings.UpgradeCheckPoints, _winPanel.GetComponent<WinPanelView>());
        _enemySpawner.Init(_settings.EnemiesCount, _settings.TimeBetweenEnemySpawn, _enemyProgression.GetComponent<EnemyProgressionBarView>());
        _upgradeMelee.Init(_settings.MaxWariorUpgradeLevel);
        _upgradeRange.Init(_settings.MaxWariorUpgradeLevel);
    }
}
