using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WinCondition { AllGemsCollected, AllMonstersDefeated }
public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameLevelSO gameLevelSO;
    [SerializeField] private GameLevelSO nextGameLevelSO;
    [SerializeField] private CollectibleObjectSO gemSO;
    [SerializeField] private CreatureSO monsterSO;
    [SerializeField] private List<Teleport> teleportList;
    [SerializeField] private List<TeleportSwitch> teleportSwitchList;

    private const float MINIMAL_PLAYBACK_SPEED = 0.5f;
    private const float MAXIMAL_PLAYBACK_SPEED = 4f;

    private List<GameObject> spawnedObjectList;

    private int _collectedGems;
    public int CollectedGems
    {
        get
        {
            return _collectedGems;
        }
        set
        {
            this._collectedGems = value;
            HandleWinConditions();
        }
    }

    private int _defeatedMonsters;
    public int DefeatedMonsters
    {
        get
        {
            return _defeatedMonsters;
        }
        set
        {
            this._defeatedMonsters = value;
            HandleWinConditions();
        }
    }

    private void HandleWinConditions()
    {
        foreach (WinCondition winCondition in gameLevelSO.winConditionList)
        {
            switch (winCondition)
            {
                case WinCondition.AllGemsCollected:
                    if (CollectedGems != gameLevelSO.gemPositionList.Count)
                    {
                        return;
                    }
                    break;
                case WinCondition.AllMonstersDefeated:
                    if (DefeatedMonsters != gameLevelSO.monsterPositionList.Count)
                    {
                        return;
                    }
                    break;
            }

        }


        // All win conditions are satisfied
        if (nextGameLevelSO != null)
        {
            ActionSceneManager.currentGameLevelSO = nextGameLevelSO;
            SceneManager.LoadScene("Scene_Gameplay_Action");
        }
        else
        {
            switch (gameLevelSO.category.ToUpper())
            {
                case "BASIC":
                    SceneManager.LoadScene("Scene_Basic_Select_Level");
                    break;
                case "LOOP":
                    SceneManager.LoadScene("Scene_Loop_Select_Level");
                    break;
                case "FUNCTION":
                    SceneManager.LoadScene("Scene_Function_Select_Level");
                    break;
            }
        }
    }


    private void Awake()
    {
        Instance = this;
        CollectedGems = 0;

        spawnedObjectList = new List<GameObject>();

    }

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadLevel()
    {
        CleanUp();

        Player.Instance.transform.position = gameLevelSO.initialPlayerPosition;
        Player.Instance.MovingDestination = gameLevelSO.initialPlayerPosition;
        Player.Instance.MovingDirection = gameLevelSO.initialPlayerMovingDirection == Vector2.zero ? new Vector2(0, -1) : gameLevelSO.initialPlayerMovingDirection;



        foreach (Vector3 gemPosition in gameLevelSO.gemPositionList)
        {
            GameObject gemObject = Instantiate(gemSO.prefab);
            gemObject.transform.position = gemPosition;

            spawnedObjectList.Add(gemObject);
        }

        foreach (Vector3 monsterPosition in gameLevelSO.monsterPositionList)
        {
            GameObject monsterObject = Instantiate(monsterSO.prefab);
            monsterObject.transform.position = monsterPosition;

            spawnedObjectList.Add(monsterObject);
        }
    }

    private void CleanUp()
    {
        foreach (GameObject spawnedObject in spawnedObjectList)
        {
            Destroy(spawnedObject);
        }
        spawnedObjectList.Clear();

        foreach (Teleport teleport in teleportList)
        {
            teleport.IsEnabled = true;
        }

        foreach (TeleportSwitch teleportSwitch in teleportSwitchList)
        {
            teleportSwitch.CloseTeleport();
        }

        CollectedGems = 0;
        DefeatedMonsters = 0;
    }

    public void Pause()
    {
        Player.Instance.IsEnabled = false;
    }

    public void IncreasePlaybackSpeed()
    {
        if (Player.Instance.SpeedMultiplier < MAXIMAL_PLAYBACK_SPEED)
        {
            Player.Instance.SpeedMultiplier += 0.5f;
            print(Player.Instance.SpeedMultiplier);
        }
    }

    public void DecreasePlaybackSpeed()
    {
        if (Player.Instance.SpeedMultiplier > MINIMAL_PLAYBACK_SPEED)
        {
            Player.Instance.SpeedMultiplier -= 0.5f;
            print(Player.Instance.SpeedMultiplier);

        }
    }


    public void Run(List<ActionModel> actionList)
    {
        LoadLevel();
        Player.Instance.IsEnabled = true;
        Player.Instance.ActionList = actionList;
    }

}
