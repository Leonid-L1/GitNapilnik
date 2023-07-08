using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Lean.Localization;

public class SettingsPanelModel 
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private List<string> _languages = new List<string>() { English, Russian, Turkish };
    private int _currentLanguageIndex = 0;

    private AudioMixerGroup _mixer;
    public event Action<string> LanguageChanged;

    public SettingsPanelModel(AudioMixerGroup mixer)
    {
        _mixer = mixer; 
        LeanLocalization.SetCurrentLanguageAll(_languages[_currentLanguageIndex]);
        LanguageChanged?.Invoke(_languages[_currentLanguageIndex]);       
    }

    public void ChangeMusicVolume(float value) => _mixer.audioMixer.SetFloat(MusicVolume, value);

    public void ChangeEffectsVolume(float value) => _mixer.audioMixer.SetFloat(EffectsVolume, value);

    public void ChangeLanguage()
    {
        if(_currentLanguageIndex < _languages.Count - 1)
            _currentLanguageIndex++;
        else
            _currentLanguageIndex = 0;

        LeanLocalization.SetCurrentLanguageAll(_languages[_currentLanguageIndex]);
        LanguageChanged?.Invoke(_languages[_currentLanguageIndex]);
    }
}
