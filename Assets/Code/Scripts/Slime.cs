using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Creature, IIDamageable
{
    

    private new void Awake()
    {
        base.Awake();
    }

    public void TakeDamage(float damage)
    {
        CurrentHP = Mathf.Clamp(CurrentHP - damage, 0, CreatureSO.maxHP);
    }
}
