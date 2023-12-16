using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBasicScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        gameObject.GetComponent<ActionSceneManager>().PlayScene("Action_Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
