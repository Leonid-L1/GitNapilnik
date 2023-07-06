using System;
using UnityEngine.SceneManagement;
public class LevelModel
{
    private int _levelNumber;
    private bool _isUnclocked;
    //private bool _isCompleted = false;
    private int _starsCount;

    public event Action<int, bool, int> ConditionsSet;

    public LevelModel(int levelNumber, bool isUnclocked, int starsCount)
    {
        _levelNumber = levelNumber;
        _isUnclocked = isUnclocked;
        _starsCount = starsCount;
    }

    public void SetStartConditions() => ConditionsSet?.Invoke(_levelNumber, _isUnclocked, _starsCount);

    public void LoadScene() => SceneManager.LoadScene(_levelNumber);

}
