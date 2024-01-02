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

    public void LoadLevel()
    {
        SceneManager.UnloadSceneAsync("Scene_Main_Menu");
        SceneManager.LoadSceneAsync("Scene_Basic_Select_Chapter", LoadSceneMode.Additive);
    }

    

    public void UnloadLevel()
    {
        SceneManager.UnloadSceneAsync("Scene_Basic_Select_Chapter");
        SceneManager.LoadSceneAsync("Scene_Main_Menu", LoadSceneMode.Additive);
    }
}
