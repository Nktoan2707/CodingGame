using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;


public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public bool IsEnabled { get; set; }

    public event EventHandler<OnInteractionEventArgs> OnInteraction;
    public class OnInteractionEventArgs : EventArgs
    {
        public IInteractable interactedObject;
    }

    public float Speed { get; private set; }
    public float RotatingSpeed { get; private set; }
    public float SpeedMultiplier { get; set; }

    private const float MOVING_UNIT = 1f;
    private const float ROTATE_LEFT_DEGREE = 90f;
    private const float ROTATE_RIGHT_DEGREE = -90f;
   

    public Vector2 MovingDirection { get; set; }
    public Vector3 MovingDestination { get; set; }
    private float movingDistance;
    public bool IsMoving { get; set; }
    private float rotatingTimer;
    private float rotatingTimerMax;
    public bool IsRotating { get; set; }

    private List<IInteractable> interactableObjectList;
    public List<ActionModel> ActionList { get; set; }

    private void Awake()
    {
        Instance = this;
        IsEnabled = true;
        Speed = 1f;
        RotatingSpeed = 3f;
        rotatingTimerMax = 0.5f;
        rotatingTimer = rotatingTimerMax;
        SpeedMultiplier = 1f;
        IsMoving = false;
        IsRotating = false;
        interactableObjectList = new List<IInteractable>();
        ActionList = new List<ActionModel>();
    }

    private void Start()
    {

    }


    private void Update()
    {
        if (!IsEnabled)
        {
            IsMoving = false;
            IsRotating = false;
            return;
        }



        movingDistance = Speed * SpeedMultiplier * Time.deltaTime;
        IsMoving = !Mathf.Approximately(Vector3.Distance(transform.position, MovingDestination), 0);


        if (IsMoving)
        {
            HandleMovement();
        }
        else if (IsRotating)
        {
            HandleRotation();
        }
        else
        {
            ExecuteAction();
        }
    }

    private void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, MovingDestination, movingDistance);
        return;
    }

    private void HandleRotation()
    {
        rotatingTimer -= Time.deltaTime * SpeedMultiplier;
        if (rotatingTimer <= 0)
        {
            rotatingTimer = rotatingTimerMax;
            IsRotating = false;
        }
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
            MovingDirection = Rotate(MovingDirection, ROTATE_LEFT_DEGREE);
            IsRotating = true;

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovingDirection = Rotate(MovingDirection, ROTATE_RIGHT_DEGREE);
            IsRotating = true;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovingDirection.Normalize();
            SetMovingDestination(transform.position + new Vector3(MovingDirection.x, MovingDirection.y));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }



        if (ActionList.Count <= 0)
        {
            return;
        }

        ActionModel action = ActionList[0];
        switch (action.actionName)
        {
            case ActionName.TurnLeft:
                MovingDirection = Rotate(MovingDirection, ROTATE_LEFT_DEGREE);
                IsRotating = true;
                break;
            case ActionName.TurnRight:
                MovingDirection = Rotate(MovingDirection, ROTATE_RIGHT_DEGREE);
                IsRotating = true;
                break;
            case ActionName.MoveForward:
                MovingDirection.Normalize();
                SetMovingDestination(transform.position + new Vector3(MovingDirection.x, MovingDirection.y));
                break;
            case ActionName.PickUp:
                Interact();
                break;
        }
        ActionList.RemoveAt(0);
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
        return MovingDirection;
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

        this.MovingDestination = newMovingDirection;
    }
}

