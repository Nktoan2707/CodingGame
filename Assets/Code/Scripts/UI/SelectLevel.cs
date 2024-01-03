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
<<<<<<< Updated upstream:Assets/Code/Scripts/UI/SelectLevel.cs
        SceneManager.UnloadSceneAsync("Scene_Main_Menu");
        SceneManager.LoadSceneAsync("Scene_Basic_Select_Chapter", LoadSceneMode.Additive);
=======
        ActionSceneManager.currentGameLevelSO = gameLevelSO;
        SceneManager.LoadSceneAsync("Action_Screen");
>>>>>>> Stashed changes:Assets/Code/Scripts/SystemScripts/BasicScreen/SelectLevel.cs
    }

    public void UnloadSelectLevel()
    {
<<<<<<< Updated upstream:Assets/Code/Scripts/UI/SelectLevel.cs
        SceneManager.UnloadSceneAsync("Scene_Basic_Select_Chapter");
        SceneManager.LoadSceneAsync("Scene_Main_Menu", LoadSceneMode.Additive);
=======
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
>>>>>>> Stashed changes:Assets/Code/Scripts/SystemScripts/BasicScreen/SelectLevel.cs
    }
}
