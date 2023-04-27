using System;
using UnityEngine;

public class CharacterHealthView : MonoBehaviour
{
    public event Action<int> DamagedRecieved;
    public void ApplyDamage(int damage) => DamagedRecieved?.Invoke(damage);

    public void ShowHealth(int health)
    {

    }
}
