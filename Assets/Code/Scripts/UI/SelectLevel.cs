using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(GameLevelSO gameLevelSO)
    {
        ActionSceneManager.currentGameLevelSO = gameLevelSO;
        SceneManager.LoadSceneAsync("Scene_Gameplay_Action");
    }

    public void UnloadSelectLevel()
    {
        SceneManager.LoadSceneAsync("Scene_Main_Menu");
    }
}
