using System.Collections;
using System.Collections.Generic;
using TS.PageSlider;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandle : MonoBehaviour
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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
    public void UnloadIntro()
    {
        SceneManager.UnloadSceneAsync("Scene_Intro");
    }
}
