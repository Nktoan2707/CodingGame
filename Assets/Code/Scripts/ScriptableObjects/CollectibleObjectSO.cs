using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleObjectSO", menuName = "ScriptableObject/CollectibleObjectSO")]

public class CollectibleObjectSO : ScriptableObject
{
    public GameObject prefab;
    public Sprite sprite;
    public string objectName;
    
}
