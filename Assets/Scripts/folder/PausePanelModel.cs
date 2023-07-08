using UnityEngine.SceneManagement;

public class PausePanelModel 
{
    private const int MainMenuIndex = 0;

    private int _currentLevelIndex;

    public PausePanelModel(int currentLevelIndex) => _currentLevelIndex = currentLevelIndex;

    public void LoadMenu() => SceneManager.LoadScene(MainMenuIndex);

    public void RestartLevel() => SceneManager.LoadScene(_currentLevelIndex);
}
