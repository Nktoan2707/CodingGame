using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionSceneManager : MonoBehaviour {
    public static List<ActionModel> initActionList = new List<ActionModel>(); 
    [SerializeField] GameObject actionList;
    [SerializeField] GameObject actionQueue;
    [SerializeField] GameObject actionFunction;

    private void Start() {
        initActionList.Add(new ActionModel(ActionName.For));
        initActionList.Add(new ActionModel(ActionName.TurnLeft));
        initActionList.Add(new ActionModel(ActionName.MoveForward));
        initActionList.Add(new ActionModel(ActionName.TurnRight));
        initActionList.Add(new ActionModel(ActionName.MoveForward));
        initActionList.Add(new ActionModel(ActionName.MoveForward));
        

        actionList.GetComponent<ActionListManager>().updateActionList();
        actionQueue.GetComponent<ActionQueueManager>().updateActionQueue();
        actionFunction.GetComponent<FunctionActionQueue>().initFunctionAction();
    }

    public static void PlayScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public static void UnloadScene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
