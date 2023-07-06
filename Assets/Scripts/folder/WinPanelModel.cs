using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinPanelModel
{
    private const int MainMenuIndex = 0;
    private const double BadResult = 0.3f;
    private const double GoodResult = 0.6f;
    private const double GreatResult = 1;

    private int _maxHealth;
    private int _nextLevelIndex;

    private  List<int> StarsAtResult = new List<int>(4) { 0,1,2,3};

    public event Action<int> ResultCounted;

    public WinPanelModel(int nextLevelIndex, int maxHealth)
    {
        _nextLevelIndex = nextLevelIndex;
        _maxHealth = maxHealth;
    }

    public void CountResult(int currentHealth)
    {          
        double result = (double)currentHealth / (double)_maxHealth;

        if (result == GreatResult)
        {

            ResultCounted?.Invoke(StarsAtResult[3]);
        }
        else if (result >= GoodResult)
        {
            ResultCounted?.Invoke(StarsAtResult[2]);
        }
        else if (result >= BadResult)
        {   
            ResultCounted?.Invoke(StarsAtResult[1]);
        }
        if (result < BadResult)
        {
            ResultCounted?.Invoke(StarsAtResult[0]);
        }
    }

    public void LoadNextlevel() => SceneManager.LoadScene(_nextLevelIndex);

    public void LoadMainMenu() => SceneManager.LoadScene(MainMenuIndex);
}


