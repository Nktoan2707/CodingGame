using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameLevelSO", menuName = "ScriptableObject/GameLevelSO")]

public class GameLevelSO : ScriptableObject
{
    public string sceneName;
    public string category;
    public int level;
    public List<WinCondition> winConditionList;
    public Vector3 initialPlayerPosition;
    public Vector2 initialPlayerMovingDirection;
    public List<Vector3> gemPositionList;
    public List<Vector3> monsterPositionList;
    public List<ActionName> actionNameList;
}
