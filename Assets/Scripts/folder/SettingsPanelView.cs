using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class SettingsPanelView : MonoBehaviour
{
    private const string ShowAnimation = "Show";
    private const string RemoveAnimation = "Remove";

    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _languageButton;
    [SerializeField] private Button _exitSettingsBitton;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectsVolume;

    private Animator _animator;

    public event Action<float> MusicVolumeChangeRequested;
    public event Action<float> EffectsVolumeChangeRequested;
    public event Action LanguageChangeRequested;

    private void Start() => _animator = GetComponent<Animator>();
    
    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _languageButton.onClick.AddListener(OnLanguageButtonCLick);
        _exitSettingsBitton.onClick.AddListener(OnExitButtonCLick);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _languageButton.onClick.RemoveListener(OnLanguageButtonCLick);
        _exitSettingsBitton.onClick.RemoveListener(OnExitButtonCLick);
    }

    public void SetSlidersStartValue(float musicVolume, float effectsVolume)
    {
        _musicVolume.value = musicVolume;
        _effectsVolume.value = effectsVolume;
    }

    public void SetMusicVolume(float newValue) => MusicVolumeChangeRequested?.Invoke(newValue);

    public void SetEffectsVolume(float newValue) => EffectsVolumeChangeRequested?.Invoke(newValue);

    public void SetPanelAsActive() => _languageButton.interactable = true;
    
    private void OnSettingsButtonClick() => _animator.Play(ShowAnimation);

    private void OnLanguageButtonCLick() => LanguageChangeRequested?.Invoke();

    private void OnExitButtonCLick()
    {
        _animator.Play(RemoveAnimation);
        _languageButton.interactable = false;
    }
}
