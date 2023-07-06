using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PausePanelModel 
{
    private const string EffectsVolume = "EffectsVolume";
    private const string MusicVolume = "MusicVolume";
    private const int MainMenuIndex = 0;

    private AudioMixerGroup _mixer;
    private int _currentLevelIndex;

    public PausePanelModel(int currentLevelIndex, AudioMixerGroup mixer)
    {
        _currentLevelIndex = currentLevelIndex;
        _mixer = mixer;
    }

    public void ChangeMusicVolume(float value) => _mixer.audioMixer.SetFloat(MusicVolume, value);

    public void ChangeEffectsVolume(float value) => _mixer.audioMixer.SetFloat(EffectsVolume, value);

    public void LoadMenu() => SceneManager.LoadScene(MainMenuIndex);

    public void RestartLevel() => SceneManager.LoadScene(_currentLevelIndex);
}
