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


}
