using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCountingManager : MonoBehaviour
{
    public static GemCountingManager Instance { get; private set; }

    [SerializeField] private GameLevelSO gameLevelSO;

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
            print($"Gem: {currentNumberOfGems}/{gameLevelSO.numberOfGems}");
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
}
