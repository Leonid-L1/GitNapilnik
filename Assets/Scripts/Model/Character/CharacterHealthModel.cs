 
using System;

public class CharacterHealthModel
{
    private int _maxHealth;
    private int _attackDamage;

    private int _health;

    public int AttackDamage => _attackDamage;
    public int MaxHealth => _maxHealth;

    public event Action <int> HealthChanged;
    public event Action Death;

    public CharacterHealthModel(int maxHealth, int Damage)
    {
        _maxHealth = maxHealth;
        _health = _maxHealth;
        _attackDamage = Damage;
    }

    public void ApplyDamage(int damage)
    {
        if (damage >= _health)
        {
            _health = 0;
            TryDie();
        }

        _health -= damage;
        HealthChanged?.Invoke(_health);

        TryDie();
    }

    private void TryDie()
    {
        if (_health <= 0)
            Death?.Invoke();
    }
}
