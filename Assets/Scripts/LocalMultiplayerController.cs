using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerController : MonoBehaviour
{
    public LocalMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5;
    public SpriteRenderer sr;
    public AudioSource SFX;
    public ParticleSystem ps;

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
            SFX.Play();
            manager.PlayerAttacking(playerInput);
        }
    }

    public void SetSprties(Sprite sprite)
    {
        sr.sprite = sprite;
        ps.textureSheetAnimation.SetSprite(0, sprite);
    }
    public void TakeDamage()
    {
        ps.Emit(10);
    }
}
