using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameLevelSO gameLevelSO;
    [SerializeField] private GameLevelSO nextGameLevelSO;
    [SerializeField] private CollectibleObjectSO gemSO;

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

    private void HandleWinConditions()
    {
        if (CollectedGems == gameLevelSO.numberOfGems)
        {
            ActionSceneManager.currentGameLevelSO = nextGameLevelSO;
            SceneManager.LoadScene("Action_Screen");
        }
    }


    private void Awake()
    {
        Instance = this;
        CollectedGems = 0;

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
        Player.Instance.transform.position = gameLevelSO.initialPlayerPosition;
        Player.Instance.MovingDestination = gameLevelSO.initialPlayerPosition;
        Player.Instance.MovingDirection = gameLevelSO.initialPlayerMovingDirection;

        foreach (Vector3 gemPosition in gameLevelSO.gemPositionList)
        {
            GameObject gemObject = Instantiate(gemSO.prefab, this.transform.parent);
            gemObject.transform.position = gemPosition;
        }


    }

    private void RunLevel()
    {

    }


    public void CatchEventQueue(List<ActionModel> actionList)
    {
        Player.Instance.ActionList = actionList;
    }
}
