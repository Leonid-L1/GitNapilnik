using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanelModel 
{
    private const int MainMenuIndex = 0;
    private int _currentLevelIndex;
    public LosePanelModel(int currentLevelIndex)
    {
        _currentLevelIndex = currentLevelIndex;
    }

    public void LoadMainMenu() => SceneManager.LoadScene(MainMenuIndex);

    public void RestartLevel() => SceneManager.LoadScene(_currentLevelIndex);

    public void Revive()
    {

    }
    
}
