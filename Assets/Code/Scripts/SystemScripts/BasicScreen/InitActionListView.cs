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
    [SerializeField] GameObject actionSlot;
    // Start is called before the first frame update
    void Start() {
        actionLayout = gameObject.GetComponent<HorizontalLayoutGroup>();
        foreach (ActionModel action  in ActionSceneManager.initActionList) {
            
            GameObject actionSlotObj = Instantiate(
                actionSlot,
                new Vector3(0,0,0),
                Quaternion.identity,
                transform
            );
            
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
