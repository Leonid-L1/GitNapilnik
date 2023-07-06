using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SettingsPanelView))]
public class SettingsPanelSetup : MonoBehaviour
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    private SettingsPanelView _view;
    private SettingsPanelModel _model;
    private SettingsPanelPresenter _presenter;

    private void Awake()
    {
        _view = GetComponent<SettingsPanelView>();
        SetCurrentVolumeValues();
        _model = new SettingsPanelModel(_mixer);
        _presenter = new SettingsPanelPresenter(_view, _model);
        _presenter.Enable();
    }

    private void SetCurrentVolumeValues()
    {
        float musicVolume = 0f;
        float effectsVolume = 0f;

        if (_mixer.audioMixer.GetFloat(MusicVolume, out float musicValue))
            musicVolume = musicValue;

        if (_mixer.audioMixer.GetFloat(EffectsVolume, out float effectsValue))
            effectsVolume = effectsValue;

        _view.SetSlidersStartValue(musicVolume, effectsVolume);
    }

    private void OnDisable() => _presenter.Disable(); 
}
