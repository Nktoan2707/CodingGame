using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;


public class Player : Creature, IIDamageable
{
    public static Player Instance { get; private set; }

    public bool IsEnabled { get; set; }

    public event EventHandler<OnInteractionEventArgs> OnInteraction;
    public class OnInteractionEventArgs : EventArgs
    {
        public IInteractable interactedObject;
    }

    public float MovingSpeed { get; private set; }
    public float SpeedMultiplier { get; set; }

    private const float MOVING_UNIT = 1f;
    private const float ROTATE_LEFT_DEGREE = 90f;
    private const float ROTATE_RIGHT_DEGREE = -90f;


    public Vector2 MovingDirection { get; set; }
    public Vector3 MovingDestination { get; set; }
    private float movingDistance;
    public bool IsMoving { get; set; }
    private float actionExecutingTimer;
    private float actionExecutingTimerMax;
    public bool IsActionExecuting { get; set; }

    private List<IInteractable> interactableObjectList;
    public List<ActionModel> ActionList { get; set; }

    private new void Awake()
    {
        base.Awake();

        Instance = this;
        IsEnabled = true;
        MovingSpeed = 1f;
        actionExecutingTimerMax = 1f;
        actionExecutingTimer = actionExecutingTimerMax;
        SpeedMultiplier = 1f;
        IsMoving = false;
        IsActionExecuting = false;
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
            IsActionExecuting = false;
            return;
        }



        movingDistance = MovingSpeed * SpeedMultiplier * Time.deltaTime;
        IsMoving = !Mathf.Approximately(Vector3.Distance(transform.position, MovingDestination), 0);


        if (IsMoving)
        {
            HandleMovement();
        }
        else if (IsActionExecuting)
        {
            HandleActionExecution();
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

    private void HandleActionExecution()
    {
        actionExecutingTimer -= Time.deltaTime * SpeedMultiplier;
        if (actionExecutingTimer <= 0)
        {
            actionExecutingTimer = actionExecutingTimerMax;
            IsActionExecuting = false;
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


        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MovingDirection = Rotate(MovingDirection, ROTATE_RIGHT_DEGREE);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MovingDirection.Normalize();
            SetMovingDestination(transform.position + new Vector3(MovingDirection.x, MovingDirection.y));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Interact(ActionName.PickUp);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(ActionName.ToggleSwitch);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            Attack();
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
                IsActionExecuting = true;
                break;
            case ActionName.TurnRight:
                MovingDirection = Rotate(MovingDirection, ROTATE_RIGHT_DEGREE);
                IsActionExecuting = true;
                break;
            case ActionName.MoveForward:
                MovingDirection.Normalize();
                SetMovingDestination(transform.position + new Vector3(MovingDirection.x, MovingDirection.y));
                break;
            case ActionName.PickUp:
                Interact(ActionName.PickUp);
                IsActionExecuting = true;

                break;
            case ActionName.Attack:
                Attack();
                IsActionExecuting = true;

                break;
            case ActionName.ToggleSwitch:
                Interact(ActionName.ToggleSwitch);
                IsActionExecuting = true;

                break;
        }
        ActionList.RemoveAt(0);
    }

    private void Interact(ActionName actionName)
    {
        if (interactableObjectList.Count <= 0)
        {
            return;
        }
        switch (actionName)
        {
            case ActionName.PickUp:
                foreach(IInteractable interactableObject in interactableObjectList)
                {
                    CollectibleGem collectibleGem = interactableObject as CollectibleGem;
                    if (collectibleGem != null)
                    {
                        collectibleGem.Interact();
                        OnInteraction?.Invoke(this, new OnInteractionEventArgs
                        {
                            interactedObject = collectibleGem
                        });
                        collectibleGem.DestroySelf();
                        break;
                    }
                }
                break;
            case ActionName.ToggleSwitch:
                foreach (IInteractable interactableObject in interactableObjectList)
                {
                    TeleportSwitch teleportSwitch = interactableObject as TeleportSwitch;
                    if (teleportSwitch != null)
                    {
                        teleportSwitch.Interact();
                        OnInteraction?.Invoke(this, new OnInteractionEventArgs
                        {
                            interactedObject = teleportSwitch
                        });
                        break;
                    }
                }
                break;
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
        float detectCircleRadius = 0.1f;
        Collider2D collider2D = Physics2D.OverlapCircle(newMovingDirection + offset, detectCircleRadius);

        // if there is something, and that is not IInteractable
        if (collider2D != null && !collider2D.gameObject.TryGetComponent<IInteractable>(out _))
        {
            return;
        }

        this.MovingDestination = newMovingDirection;
    }

    public void TakeDamage(float damage)
    {
        CurrentHP = Mathf.Clamp(CurrentHP - damage, 0, CreatureSO.maxHP);
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    protected override void Die() { 
        IsEnabled = false;
    }

    public void Attack()
    {
        Vector3 offset = new Vector3(0.5f, 0.5f, 0);
        Vector3 attackPosition = transform.position + new Vector3(MovingDirection.x, MovingDirection.y);
        float attackCircleRadius = 0.1f;

        Collider2D collider2D = Physics2D.OverlapCircle(attackPosition + offset, attackCircleRadius);
        if (collider2D == null)
        {
            return;
        }

        if (collider2D.gameObject.TryGetComponent<Creature>(out Creature attackedCreature))
        {
            CombatManager.Instance.HandleCombatTurn(this, attackedCreature);
        }
    }
}

