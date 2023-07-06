using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private Button _levelButton;
    [SerializeField] TMP_Text _levelNumber;
    [SerializeField] private List<Image> _stars;
    [SerializeField] private Image _lockImage;
    
    public event Action ButtonClicked;

    private void OnEnable()
    {
        _levelButton.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _levelButton.onClick.RemoveListener(OnButtonClicked);
    }

    public void SetStartConditions(int levelNumber, bool isUnlocked, int starsCount)
    {
        _levelNumber.text = levelNumber.ToString();

        _levelButton.interactable = isUnlocked;

        if (isUnlocked)
        {
            _lockImage.enabled = false;
        }
        else 
        {
            _lockImage.enabled = true;
        }
            

        if (starsCount < 0)
            return;

        for (int i = 0; i < starsCount; i++)
            _stars[i].enabled = true;
    }

    private void OnButtonClicked()
    {
        Debug.Log("clicked");
        ButtonClicked?.Invoke();
    }  
}
