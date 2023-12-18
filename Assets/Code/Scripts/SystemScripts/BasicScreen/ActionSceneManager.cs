using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionSceneManager : MonoBehaviour {
    public static List<ActionModel> initActionList = new List<ActionModel>(); 
    [SerializeField] GameObject actionList;
    [SerializeField] GameObject actionQueue;

    private void Start() {
        initActionList.Add(new ActionModel("UP"));
        initActionList.Add(new ActionModel("DOWN"));
        initActionList.Add(new ActionModel("LEFT"));
        initActionList.Add(new ActionModel("RIGHT"));
        initActionList.Add(new ActionModel("PICKUP"));
        actionList.GetComponent<ActionListManager>().updateActionList();
        actionQueue.GetComponent<ActionQueueManager>().updateActionQueue();
    }

    public void PlayScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
