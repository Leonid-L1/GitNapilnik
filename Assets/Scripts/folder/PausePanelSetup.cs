using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(PausePanelView))]
public class PausePanelSetup : MonoBehaviour
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    private PausePanelView _view;
    private PausePanelModel _model;
    private PausePanelPresenter _presenter;

    public void Init(int currentLevelIndex)
    {       
        _view = GetComponent<PausePanelView>();
        SetCurrentVolumeValues();
        _model = new PausePanelModel(currentLevelIndex, _mixer);
        _presenter = new PausePanelPresenter(_model, _view);
        _presenter.Enable();

    }

    private void SetCurrentVolumeValues()
    {
        float musicVolume = 0f;
        float effectsVolume = 0f;

        if(_mixer.audioMixer.GetFloat(MusicVolume, out float musicValue) )
            musicVolume = musicValue;

        if (_mixer.audioMixer.GetFloat(EffectsVolume, out float effectsValue))
            effectsVolume = effectsValue;

        _view.SetSlidersStartValue(musicVolume, effectsVolume);
    }
    private void OnDisable() => _presenter.Disable();
}
