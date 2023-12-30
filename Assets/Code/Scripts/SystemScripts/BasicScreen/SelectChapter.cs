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
        ActionSceneManager.initActionList.Add(new ActionModel(ActionName.TurnLeft));
        ActionSceneManager.initActionList.Add(new ActionModel(ActionName.TurnRight));
        ActionSceneManager.initActionList.Add(new ActionModel(ActionName.MoveForward));
        ActionSceneManager.initActionList.Add(new ActionModel(ActionName.PickUp));
        SceneManager.LoadSceneAsync("Action_Screen");
    }
}
