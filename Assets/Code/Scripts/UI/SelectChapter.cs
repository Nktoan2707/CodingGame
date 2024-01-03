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

    public void LoadBasicSelectLevel()
    {
        SceneManager.LoadSceneAsync("Scene_Basic_Select_Level");
    }

    public void LoadFunctionSelectLevel()
    {
        SceneManager.LoadSceneAsync("Scene_Function_Select_Level");
    }

    public void LoadLoopSelectLevel()
    {
        SceneManager.LoadSceneAsync("Scene_Loop_Select_Level");
    }
}
