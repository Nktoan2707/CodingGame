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

    public void LoadChapter(int level)
    {
        SceneManager.UnloadSceneAsync("Scene_Select_Chapter");
        SceneManager.LoadSceneAsync("Action_Screen");
    }
}
