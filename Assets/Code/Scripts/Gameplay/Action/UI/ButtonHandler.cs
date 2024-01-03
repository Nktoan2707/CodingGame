using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {
    [SerializeField] GameObject actionQueueList;

    public void OnPauseClick()
    {
        LevelManager.Instance.Pause();
    }

    public void OnSlowerClick()
    {
        LevelManager.Instance.DecreasePlaybackSpeed();

    }

    public void OnFasterClick()
    {
        LevelManager.Instance.IncreasePlaybackSpeed();

    }

    public void OnRunClick() {
        List<ActionModel> actionQueue = actionQueueList.GetComponent<ActionQueueManager>().getActionList();
        LevelManager.Instance.Run(actionQueue);
    }


    public void OnStopClick()
    {
        SceneManager.LoadScene("Scene_Gameplay_Action");

    }

    public void OnOpenTutorial() 
    {
        if (ActionSceneManager.currentGameLevelSO.tutorialSceneName == null) {
            return;
        }
        SceneManager.LoadSceneAsync(ActionSceneManager.currentGameLevelSO.tutorialSceneName, LoadSceneMode.Additive);
    }

    public void OnBackButton() {
        switch(ActionSceneManager.currentGameLevelSO.category.ToUpper()) {
            case "BASIC": {
                SceneManager.LoadSceneAsync("Scene_Basic_Select_Level");
                break;
            }
            case "FUNCTION": {
                SceneManager.LoadSceneAsync("Scene_Function_Select_Level");
                break;
            }
            case "LOOP": {
                SceneManager.LoadSceneAsync("Scene_Loop_Select_Level");
                break;
            }
            default: {
                SceneManager.LoadSceneAsync("Scene_Main_Menu");
                break;
            }
        }
    }

}
