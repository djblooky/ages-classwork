using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Tooltip("How fast the player turns, 0 = no turning, 1 = instant turning")]
    [Range(0, 1)]
    private float turnSpeed = 0.1f;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    private Animator animator;

    private readonly int isMovingAnimParam = Animator.StringToHash("moveInput");

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 cameraRelativeInputDirection = GetCameraRelativeInputDirection();

        UpdatePhysicsMaterial();
        Move(cameraRelativeInputDirection);
        RotateTowardMoveDirection(cameraRelativeInputDirection);
    }

    /// <summary>
    /// Turning the character to face a given direction they are moving in
    /// </summary>
    /// <param name="direction">The direction the character is trying to move in</param>
    private void RotateTowardMoveDirection(Vector3 direction)
    {
        //rotate player relative to camera
        if (direction.magnitude > 0) //the player is pressing input keys
        {
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);
        }
    }

    /// <summary>
    /// Moves the player in a direction based on its max speed and acceleration
    /// </summary>
    /// <param name="moveDirection">The direction to move in</param>
    private void Move(Vector3 moveDirection)
    {
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(moveDirection * accelerationForce, ForceMode.Acceleration);
        }
    }

    /// <summary>
    /// Updates the physics material to a low friction option if the player is moving, or high friction if they are stopping
    /// </summary>
    private void UpdatePhysicsMaterial()
    {
        collider.material = input.magnitude > 0 ? movingPhysicsMaterial : stoppingPhysicsMaterial;
    }

    /// <summary>
    /// Calculates a Vector3 to move the player relative to camera
    /// </summary>
    /// <returns>A Vector3 for the camera relative input direction</returns>
    private Vector3 GetCameraRelativeInputDirection()
    {
        var inputDirection = new Vector3(input.x, 0, input.y);

        Vector3 flattenedCameraForward = Camera.main.transform.forward;
        flattenedCameraForward.y = 0; //get rid of the y component of the vector - stops player from moving up or down
        var CameraRotation = Quaternion.LookRotation(flattenedCameraForward);

        return CameraRotation * inputDirection;
    }

    /// <summary>
    /// This event handler is called from the Player Input component using the new input system
    /// </summary>
    /// <param name="context">A Vector2 representing the player move input</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

}
