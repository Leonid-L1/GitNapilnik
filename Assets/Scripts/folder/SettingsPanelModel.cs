using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanelModel 
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";

    private AudioMixerGroup _mixer;

    public SettingsPanelModel(AudioMixerGroup mixer)
    {
        _mixer = mixer;     
    }

    public void ChangeMusicVolume(float value) => _mixer.audioMixer.SetFloat(MusicVolume, value);

    public void ChangeEffectsVolume(float value) => _mixer.audioMixer.SetFloat(EffectsVolume, value);

    public void ChangeLanguage()
    {

    }
}
