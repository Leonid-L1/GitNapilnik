using System;
using UnityEngine;

public class BlockModel 
{
    private BoxCollider _collider;
    public Transform CombatantContainer { get; private set; }

    public BlockModel(BoxCollider collider, Transform combatantContainer)
    {
        _collider = collider;
        CombatantContainer = combatantContainer;
    }

    public void SetAsDropped() => _collider.enabled = false;
    
}
