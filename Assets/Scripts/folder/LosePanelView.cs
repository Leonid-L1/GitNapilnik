using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(TimeScaleController))]
public class LosePanelView : MonoBehaviour
{
    private const string ShowAnimation = "ShowWithStopTime";
    private const string RemoveAnimation = "RemoveAndStartTime";
    
    [SerializeField] private Button _reviveButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _menuButton;

    private TimeScaleController _timeScaleController;
    private Animator _animator;
    private AudioSource _loseSound;

    public event Action ReviveRequested;
    public event Action RestartRequested;
    public event Action MenuRequested;

    private void Start()
    {
        _animator = GetComponent<Animator>();   
        _timeScaleController = GetComponent<TimeScaleController>();
        _loseSound = GetComponent<AudioSource>();         
    }


    private void OnEnable()
    {
        _reviveButton.onClick.AddListener(OnReviveButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _menuButton.onClick.AddListener(OnMenuButtonClick);
    }

    private void OnDisable()
    {
        _reviveButton.onClick.RemoveListener(OnReviveButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
    }

    public void Show()
    {
        _animator.Play(ShowAnimation);
        _loseSound.Play();
    }

    public void Remove() => _animator.Play(RemoveAnimation);
    

    private void OnReviveButtonClick()
    {
        _timeScaleController.StartTime();
        ReviveRequested?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        _timeScaleController.StartTime();
        RestartRequested?.Invoke();
    }

    private void OnMenuButtonClick()
    {
        _timeScaleController.StartTime();
        MenuRequested?.Invoke();
    }
}
