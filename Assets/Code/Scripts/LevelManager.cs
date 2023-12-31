using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameLevelSO gameLevelSO;
    [SerializeField] private GameLevelSO nextGameLevelSO;
    [SerializeField] private CollectibleObjectSO gemSO;

    private int currentNumberOfGems;
    public int CurrentNumberOfGems
    {
        get
        {
            return currentNumberOfGems;
        }
        set
        {
            this.currentNumberOfGems = value;
        }
    }

    private void Awake()
    {
        Instance = this;
        CurrentNumberOfGems = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadLevel()
    {
        Player.Instance.transform.position = gameLevelSO.initialPlayerPosition;
        foreach (Vector3 position in gameLevelSO.gemPositionList)
        {
            
        }
    }

    private void RunLevel()
    {

    }
}
