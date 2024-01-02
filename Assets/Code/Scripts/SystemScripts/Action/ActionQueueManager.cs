using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionQueueManager : MonoBehaviour
{
    public static ActionQueueManager Instance { get; private set; }
    [SerializeField] GameObject actionSlot;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void updateActionQueue()
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
        GameObject actionQueueListView = transform.parent.gameObject;
        RectTransform rectTransform = actionQueueListView.GetComponent<RectTransform>();
        if (haveFunction)
        {
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)488.36);

            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x,
                (float)244.18
            );
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x,
                (float)76.67999
            );
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)823.36);
        }
    }

    public List<ActionModel> getActionList()
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
                    case "ACTIONFUNCTION(CLONE)":
                        {
                            result.AddRange(FunctionActionQueue.Instance.getActionFunctionList());
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

                            result.Add(new ActionModel(ActionName.ToggleSwitch));
                            break;
                        }
                    case "ACTIONATTACK(CLONE)":
                        {
                            result.Add(new ActionModel(ActionName.Attack));
                            break;
                        }
                }
            }
        }
        return result;
    }
}
