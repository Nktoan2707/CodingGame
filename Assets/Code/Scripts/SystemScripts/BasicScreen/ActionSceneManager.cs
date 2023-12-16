using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionSceneManager : MonoBehaviour {
    [SerializeField] public static List<ActionModel> initActionList = new List<ActionModel>();

    private void Start() {
        initActionList.Add(new ActionModel("UP"));
        initActionList.Add(new ActionModel("UP"));
        initActionList.Add(new ActionModel("UP"));
        initActionList.Add(new ActionModel("UP"));
    }

    public void PlayScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName) {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
