using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureSO", menuName = "ScriptableObject/CreatureSO")]
public class CreatureSO : ScriptableObject
{
    public GameObject prefab;
    public string creatureName;
    public Sprite sprite;
    public float maxHP;
    public float baseATK;
    public float baseSPD;
}
