using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitActionListView : MonoBehaviour
{
    public static HorizontalLayoutGroup actionLayout;
    [SerializeField] GameObject actionUp;
    [SerializeField] GameObject actionDown;
    [SerializeField] GameObject actionRight;
    [SerializeField] GameObject actionLeft;
    // Start is called before the first frame update
    void Start() {
        actionLayout = gameObject.GetComponent<HorizontalLayoutGroup>();
        foreach (ActionModel action  in ActionSceneManager.initActionList) {
            switch (action.actionName.ToUpper()) {
                case "UP":
                    Instantiate(
                        actionUp,
                        new Vector3(0,0,0),
                        Quaternion.identity,
                        transform
                    );
                    break;
                case "DOWN":
                    Instantiate(
                        actionDown,
                        new Vector3(0,0,0),
                        Quaternion.identity,
                        transform
                    );
                    break;
                case "LEFT":
                    Instantiate(
                        actionLeft,
                        new Vector3(0,0,0),
                        Quaternion.identity,
                        transform
                    );
                    break;
                case "RIGHT":
                    Instantiate(
                        actionRight,
                        new Vector3(0,0,0),
                        Quaternion.identity,
                        transform
                    );
                    break;
                default: break;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
