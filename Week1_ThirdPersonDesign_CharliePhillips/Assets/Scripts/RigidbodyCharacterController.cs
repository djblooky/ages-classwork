using UnityEngine;

public class RigidbodyCharacterController : MonoBehaviour
{
    [SerializeField]
    private float accelerationForce = 10;

    [SerializeField]
    private float maxSpeed = 2;

    [SerializeField]
    [Tooltip("How fast the player turns, 0 = no turning, 1 = instant turning")]
    [Range(0,1)]
    private float turnSpeed = 0.1f;

    [SerializeField]
    private PhysicMaterial stoppingPhysicsMaterial, movingPhysicsMaterial;

    private new Rigidbody rigidbody;
    private Vector2 input;
    private new Collider collider;
    

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        /// Move player relative to camera
        var inputDirection = new Vector3(input.x, 0, input.y);

        Vector3 flattenedCameraForward = Camera.main.transform.forward;
        flattenedCameraForward.y = 0; //get rid of the y component of the vector - stops player from moving up or down
        var CameraRotation = Quaternion.LookRotation(flattenedCameraForward);

        Vector3 cameraRelativeInputDirection = CameraRotation * inputDirection;

        collider.material = inputDirection.magnitude > 0 ?  movingPhysicsMaterial : stoppingPhysicsMaterial;

        if(rigidbody.velocity.magnitude < maxSpeed)
        {
            rigidbody.AddForce(cameraRelativeInputDirection * accelerationForce, ForceMode.Acceleration);
        }

        //rotate player relative to camera
        if (cameraRelativeInputDirection.magnitude > 0) //the player is pressing input keys
        {
            var targetRotation = Quaternion.LookRotation(cameraRelativeInputDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);
        }
       
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

    }
}
