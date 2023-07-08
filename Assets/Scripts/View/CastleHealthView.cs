using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private float _step = 0.1f;

    public int CurrentHealth { get; private set; }

    public event Action EnemyEntered;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
            EnemyEntered?.Invoke();          
        }
    }

    public void Init(int maxSliderValue)
    {   
        CurrentHealth = maxSliderValue;
        _slider.maxValue = maxSliderValue;
        _slider.value = _slider.maxValue;
    }
   
    public void OnHealthChanged(int newValue)
    {          
        StartCoroutine(UpdateSlider(newValue));
    }

    public IEnumerator UpdateSlider(int newValue)
    {   
        CurrentHealth = newValue;

        while (true)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newValue, _step);

            if (_slider.value == newValue)
            {
                yield break;
            }
            else
            {
                yield return null;
            }
        }
    }
}
