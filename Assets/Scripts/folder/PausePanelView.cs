using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(TimeScaleController))]
public class PausePanelView : MonoBehaviour
{
    private const string ShowAnimation = "ShowWithStopTime";
    private const string RemoveAnimation = "RemoveAndStartTime";   

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectsVolume;

    private Animator _animator;
    private TimeScaleController _timeScaleController;
    private List<Button> _buttons = new List<Button>(3);   

    public event Action<float> MusicVolumeChangeRequested;
    public event Action<float> EffectsVolumeChangeRequested;
    public event Action RestartRequsted;
    public event Action MenuRequested;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _timeScaleController = GetComponent<TimeScaleController>();
        _buttons.Add(_continueButton);
        _buttons.Add(_restartButton);
        _buttons.Add(_mainMenuButton);

        foreach (Button button in _buttons)
            button.interactable = false;
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _continueButton.onClick.AddListener(OnContinueBittonClick);
        _restartButton.onClick.AddListener(OnRestartButtonCLick);
        _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueBittonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonCLick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClick);
    }
    
    public void SetSlidersStartValue(float musicVolume, float effectsVolume)
    {
        _musicVolume.value = musicVolume;
        _effectsVolume.value = effectsVolume;
    }

    public void SetPanelAsActive()
    {
        _pauseButton.interactable = false;

        foreach (Button button in _buttons)
            button.interactable = true;
    }

    public void SetMusicVolume(float newValue) => MusicVolumeChangeRequested?.Invoke(newValue);

    public void SetEffectsVolume(float newValue) => EffectsVolumeChangeRequested?.Invoke(newValue);

    private void OnPauseButtonClick() => _animator.Play(ShowAnimation);

    private void OnContinueBittonClick()
    {
        _animator.Play(RemoveAnimation);
        _pauseButton.interactable = true;

        foreach (Button button in _buttons)
            button.interactable = false;
    }

    private void OnRestartButtonCLick()
    {
        _timeScaleController.StartTime();
        RestartRequsted?.Invoke();
    }

    private void OnMainMenuButtonClick()
    {
        _timeScaleController.StartTime();
        MenuRequested?.Invoke();
    }
}
