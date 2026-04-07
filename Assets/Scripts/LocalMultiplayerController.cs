using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerController : MonoBehaviour
{
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;

    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Attacking!");
            manager.PlayerAttacking(playerInput);
        }
    }
}
