using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Purchasing;


public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public bool IsEnabled { get; private set; }

    public event EventHandler<OnInteractionEventArgs> OnInteraction;
    public class OnInteractionEventArgs : EventArgs
    {
        public IInteractable interactedObject;
    }

    public float Speed { get; private set; }
    public float SpeedMultiplier { get; set; }

    private const float MOVING_UNIT = 1f;
    private const float ROTATE_LEFT_DEGREE = 90f;
    private const float ROTATE_RIGHT_DEGREE = -90f;
    private Vector2 movingDirection;
    private float movingDistance;
    private Vector3 movingDestination;
    public bool IsMoving { get; set; }

    private List<IInteractable> interactableObjectList;
    private List<ActionModel> actionList;

    private void Awake()
    {
        Instance = this;
        IsEnabled = true;

        Speed = 3f;
        SpeedMultiplier = 1f;

        transform.position = Vector3.zero;
        movingDirection = new Vector2(1, 0);
        movingDestination = transform.position;
        IsMoving = false;
        interactableObjectList = new List<IInteractable>();
        actionList = new List<ActionModel>();
    }

    private void Start()
    {

    }


    private void Update()
    {
        movingDistance = Speed * SpeedMultiplier * Time.deltaTime;
        IsMoving = !Mathf.Approximately(Vector3.Distance(transform.position, movingDestination), 0);

        if (IsMoving)
        {
            HandleMovement();
        }
        else
        {
            ExecuteAction();
        }
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movingDestination, movingDistance);
        IsMoving = true;
        return;
    }

    private Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    private void ExecuteAction()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingDirection = Rotate(movingDirection, ROTATE_LEFT_DEGREE);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movingDirection = Rotate(movingDirection, ROTATE_RIGHT_DEGREE);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movingDirection.Normalize();
            SetMovingDestination(transform.position + new Vector3(movingDirection.x, movingDirection.y));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }



        //if (actionList.Count <= 0)
        //{
        //    return;
        //}

        //ActionModel action = actionList[0];
        //switch (action.actionName.ToUpper())
        //{
        //    case "UP":
        //        movingDirection.y = movingUnit;
        //        break;
        //    case "DOWN":
        //        movingDirection.y = -movingUnit;
        //        break;
        //    case "LEFT":
        //        movingDirection.x = -movingUnit;
        //        break;
        //    case "RIGHT":
        //        movingDirection.x = movingUnit;
        //        break;
        //    case "PICKUP":
        //        Interact();
        //        break;
        //}

       

        //actionList.RemoveAt(0);
    }

    private void Interact()
    {
        if (interactableObjectList.Count <= 0)
        {
            return;
        }

        interactableObjectList[0].Interact();
        OnInteraction?.Invoke(this, new OnInteractionEventArgs
        {
            interactedObject = interactableObjectList[0]
        });

        // if interacted object is a gem
        CollectibleGem collectibleGem = interactableObjectList[0] as CollectibleGem;
        if (collectibleGem != null)
        {
            collectibleGem.DestroySelf();
        }
    }

    public void AddInteractableObject(IInteractable interactableObject)
    {
        interactableObjectList.Add(interactableObject);
    }

    public void RemoveInteractableObject(IInteractable interactableObject)
    {
        interactableObjectList.Remove(interactableObject);
    }

    public Vector2 GetMovingDirection()
    {
        return movingDirection;
    }

    private void SetMovingDestination(Vector3 newMovingDirection)
    {
        Vector3 offset = new Vector3(0.5f, 0.5f, 0);
        Collider2D collider2D = Physics2D.OverlapCircle(newMovingDirection + offset, 0.1f);

        // if there is something, and that is not IInteractable
        if (collider2D != null && !collider2D.gameObject.TryGetComponent<IInteractable>(out _))
        {
            return;
        }

        this.movingDestination = newMovingDirection;
    }

    public void CatchEventQueue(List<ActionModel> actionList)
    {
        string logString = "";
        foreach (ActionModel actionModel in actionList)
        {
            logString += $" > {actionModel.actionName}";
        }
        Debug.Log("Action Queue: " + logString);

        this.actionList = actionList;
    }
}

