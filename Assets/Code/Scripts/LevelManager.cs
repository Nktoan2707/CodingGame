using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (value == gameLevelSO.numberOfGems)
            {
                
            }
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
        Player.Instance.MovingDirection = gameLevelSO.initialPlayerMovingDirection;
        Player.Instance.MovingDestination = gameLevelSO.initialPlayerMovingDirection;

        foreach (Vector3 gemPosition in gameLevelSO.gemPositionList)
        {
            GameObject gemObject = Instantiate(gemSO.prefab);
            gemObject.transform.position = gemPosition;
        }


    }

    private void RunLevel()
    {

    }
}
