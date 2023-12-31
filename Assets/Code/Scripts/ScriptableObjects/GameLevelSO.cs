using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameLevelSO : ScriptableObject
{
    public string sceneName;
    public string category;
    public int level;
    public int numberOfGems;
    public List<Vector3> gemPositionList;
    public Vector3 initialPlayerPosition;
    public Vector2 initialPlayerMovingDirection;
    public List<ActionName> actionNameList;
}
