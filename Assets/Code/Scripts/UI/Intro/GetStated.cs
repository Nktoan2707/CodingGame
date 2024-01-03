using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetStarted : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("Scene_MainMenu", LoadSceneMode.Additive);
    }

    

    public void UnloadIntro()
    {
        SceneManager.UnloadSceneAsync("Scene_Intro");
    }
}
