using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Creature : MonoBehaviour
{
    [SerializeField] CreatureSO creatureSO;
    public CreatureSO CreatureSO
    {
        get
        {
            return creatureSO;
        }
    }
    public float CurrentHP { get; set; }
    public float CurrentATK { get; set; }
    public float CurrentSPD { get; set; }

    protected void Awake()
    {
        CurrentHP = CreatureSO.maxHP;
        CurrentATK = CreatureSO.baseATK;
        CurrentSPD = CreatureSO.baseSPD;
    }

    public bool IsAlive()
    {
        return CurrentHP > 0;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
