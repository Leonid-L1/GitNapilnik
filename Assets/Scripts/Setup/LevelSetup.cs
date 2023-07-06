using UnityEngine;

[RequireComponent(typeof(LevelView))]
public class LevelSetup : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private bool _isUnlocked = false;
    [SerializeField] private int _starsCount;

    private LevelPresenter _presenter;
    private LevelModel _model;
    private LevelView _view;

    private void Awake()
    {
        _view = GetComponent<LevelView>();
        _model = new LevelModel(_levelNumber,_isUnlocked, _starsCount);
        _presenter = new LevelPresenter(_model,_view);
    }

    private void OnEnable() => _presenter.Enable();
 
    private void OnDisable() => _presenter.Disable();

    
}
