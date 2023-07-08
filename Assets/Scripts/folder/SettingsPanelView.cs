using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelView : MonoBehaviour
{

    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _languageButton;
    [SerializeField] private Button _exitSettingsBitton;
    [SerializeField] private Slider _musicVolume;
    [SerializeField] private Slider _effectsVolume;

    [SerializeField] private Image _currentLanguageFlag;
    [SerializeField] private Sprite _englishFlag;
    [SerializeField] private Sprite _russianFlag;
    [SerializeField] private Sprite _turkishFlag;

    public event Action<float> MusicVolumeChangeRequested;
    public event Action<float> EffectsVolumeChangeRequested;
    public event Action LanguageChangeRequested;
    
    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonCLick);
        _languageButton.onClick.AddListener(OnLanguageButtonCLick);
        _exitSettingsBitton.onClick.AddListener(OnExitButtonCLick);        
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonCLick);
        _languageButton.onClick.RemoveListener(OnLanguageButtonCLick);
        _exitSettingsBitton.onClick.RemoveListener(OnExitButtonCLick);
    }

    public void UpdateLanguageButton(string languageName)
    {
        switch (languageName)
        {
            case "English":
                _currentLanguageFlag.sprite = _englishFlag;
                break;
            case "Russian":
                _currentLanguageFlag.sprite = _russianFlag;
                break;
            case "Turkish":
                _currentLanguageFlag.sprite = _turkishFlag;
                break;
        }
    }
    public void SetSlidersStartValue(float musicVolume, float effectsVolume)
    {
        _musicVolume.value = musicVolume;
        _effectsVolume.value = effectsVolume;
    }

    public void SetMusicVolume(float newValue) => MusicVolumeChangeRequested?.Invoke(newValue);

    public void SetEffectsVolume(float newValue) => EffectsVolumeChangeRequested?.Invoke(newValue);

    public void SetPanelAsActive() => _languageButton.interactable = true;  

    private void OnSettingsButtonCLick() => _settingsButton.interactable = false;

    private void OnLanguageButtonCLick() => LanguageChangeRequested?.Invoke();

    private void OnExitButtonCLick()
    {
        _settingsButton.interactable = true;
        _languageButton.interactable = false;
    }
}
