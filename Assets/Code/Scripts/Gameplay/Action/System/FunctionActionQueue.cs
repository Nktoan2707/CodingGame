using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionActionQueue : MonoBehaviour
{
    public static FunctionActionQueue Instance { get; private set; }
    [SerializeField] GameObject actionSlot;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void initFunctionAction()
    {
        List<ActionModel> actionList = ActionSceneManager.initActionList;

        bool haveFunction = false;

        foreach (ActionModel actionModel in actionList)
        {
            if (actionModel.actionName == ActionName.Function)
            {
                haveFunction = true;
            }

            GameObject InstantiatedActionSlot = Instantiate(actionSlot);
            InstantiatedActionSlot.transform.SetParent(transform);
        }

        GameObject actionFunctionView = transform.parent.gameObject;
        if (haveFunction)
        {
            actionFunctionView.SetActive(true);
        }
        else
        {
            actionFunctionView.SetActive(false);
        }
    }
    public List<ActionModel> getActionFunctionList()
    {
        List<ActionModel> result = new List<ActionModel>();
        foreach (Transform actionSlotGameObject in transform)
        {
            foreach (Transform actionGameObject in actionSlotGameObject)
            {
                switch (actionGameObject.name.ToUpper())
                {
                    case "ACTIONTURNLEFT(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.TurnLeft));
                            break;
                        }
                    case "ACTIONTURNRIGHT(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.TurnRight));
                            break;
                        }
                    case "ACTIONMOVEFORWARD(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.MoveForward));
                            break;
                        }
                    case "ACTIONPICKUP(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.PickUp));
                            break;
                        }
                    case "ACTIONFOR(CLONE)":
                        {
                            ActionForManager currentFor = actionGameObject.gameObject.GetComponent<ActionForManager>();
                            result.AddRange(currentFor.getActionForLoop());
                            break;
                        }
                    case "ACTIONTOGGLESWITCH(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.MoveForward));
                            break;
                        }
                    case "ACTIONATTACK(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.MoveForward));
                            break;
                        }

                }
            }
        }
        return result;
    }
}
