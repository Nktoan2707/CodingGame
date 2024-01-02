using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Creature : MonoBehaviour
{
    [SerializeField] public CreatureSO CreatureSO { get; }
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
}
