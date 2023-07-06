using System;
public class CastleHealthModel 
{
    private int _health;
    public event Action<int> HealthChanged;
    public event Action HealthIsGone;

    public CastleHealthModel(int health)
    {
        _health = health;
    }

    public void ApplyDamage()
    {   
        if(_health <= 0) 
            return;

        _health--;
        HealthChanged?.Invoke(_health);

        if(_health <= 0)
            HealthIsGone?.Invoke();               
    }
}
