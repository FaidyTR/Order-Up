using UnityEngine;
using System;
public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }
    public event EventHandler <OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float PlayerMoveSpeed = 7f;
    [SerializeField] private LayerMask countersLayerMask;
    [SerializeField] private Transform kitchenObjectHoldPoint; 
    private BaseCounter selecterCounter;
    private KitchenObject kitchenObject;
    private Vector3 lastInteractDirection;
    private bool isWalking;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
    }
    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnInteractAlternateEvent += GameInput_OnInteractAlternateEvent;
    }
    private void GameInput_OnInteractAlternateEvent(object sender, System.EventArgs e)
    {
        if (selecterCounter != null) { selecterCounter.InteractAlternate(this); }
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selecterCounter != null) { selecterCounter.Interact(this);}
    }
    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }
    private void HandleInteraction()
    {
        Vector2 inputVector = gameInput.GetInputVector().normalized;
        Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y);
        float InteractDistance = 2f;

        if (directionVector != Vector3.zero)
        {
            lastInteractDirection = directionVector;
        }
        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit raycastHit, InteractDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<BaseCounter>(out BaseCounter baseCounter))
            {
                if (baseCounter != selecterCounter)
                {
                    selecterCounter = baseCounter;
                }
            } else { selecterCounter = null;}
        } else { selecterCounter = null; }
        SetSelectedCounter(selecterCounter);
    }
    private void HandleMovement() 
    {
        Vector2 inputVector = gameInput.GetInputVector().normalized;
        Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y);
        float playerHeight = 2f;
        float playerRadius = .7f;
      
        float moveDistance = Time.deltaTime * PlayerMoveSpeed;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
            playerRadius, directionVector, moveDistance);
        if (!canMove )
        {

            Vector3 directionVectorX = new Vector3(directionVector.x, 0, 0);
            canMove = directionVector.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
                playerRadius, directionVectorX, moveDistance);
            if (canMove)
            {
                directionVector = directionVectorX.normalized;
            }
            else
            {
                Vector3 directionVectorZ= new Vector3(0, 0, directionVector.z);
                canMove = directionVector.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, 
                    playerRadius, directionVectorZ, moveDistance);
                if (canMove)
                {
                    directionVector = directionVectorZ.normalized;
                }
            }
        }
        if (canMove)
        {
            transform.position += directionVector * moveDistance;
            isWalking = directionVector != Vector3.zero;
            float rotateSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, directionVector, Time.deltaTime * rotateSpeed);

        }
        
    }
    public bool IsWalking()
    {
        return isWalking;

    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.selecterCounter = selectedCounter;
        if (OnSelectedCounterChanged != null)
        {
            OnSelectedCounterChanged(this, new OnSelectedCounterChangedEventArgs
            {
                selectedCounter = selecterCounter
            });
        }
    }
    public Transform GetTransformPosition()
    {
        return kitchenObjectHoldPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    { this.kitchenObject = kitchenObject; }
    public KitchenObject GetKitchenObject()
    { return kitchenObject; }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}

