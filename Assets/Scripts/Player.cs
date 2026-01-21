using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float PlayerMoveSpeed = 7f;
    private bool isWalking;
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) { inputVector.y += 1; }
        if (Input.GetKey(KeyCode.S)) { inputVector.y -= 1; }
        if (Input.GetKey(KeyCode.D)) { inputVector.x += 1; }
        if (Input.GetKey(KeyCode.A)) { inputVector.x -= 1; }
        Vector3 directionVector = new Vector3(inputVector.x, 0, inputVector.y).normalized;
        transform.position += directionVector * Time.deltaTime * PlayerMoveSpeed;
        isWalking = directionVector != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, directionVector, Time.deltaTime * rotateSpeed);
    }
    public bool IsWalking()
    {
        return isWalking;

    }
}

