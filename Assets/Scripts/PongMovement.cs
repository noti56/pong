using UnityEngine.InputSystem;
using UnityEngine;

public class PongMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private InputActionReference inputActionReference;
    private GameManager gameManager;

    // Start is called before the first frame update
    private void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        inputActionReference.action.Enable();
        inputActionReference.action.performed += OnMovementAction;
        inputActionReference.action.canceled += OnMovementAction;


    }

    private void OnDisable()
    {
        inputActionReference.action.performed -= OnMovementAction;
        inputActionReference.action.canceled -= OnMovementAction;
        inputActionReference.action.Disable();
    }

    public void OnMovementAction(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveInput == Vector2.zero) return;
        Vector2 movement = new Vector2(0, moveInput.y * speed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }
}
