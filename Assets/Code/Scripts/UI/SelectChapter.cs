using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadChapter(GameLevelSO gameLevelSO)
    {
        ActionSceneManager.currentGameLevelSO = gameLevelSO;
        SceneManager.LoadSceneAsync("Scene_Gameplay_Action");
    }
}
