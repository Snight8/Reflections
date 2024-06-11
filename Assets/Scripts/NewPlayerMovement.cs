using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool isMirrorX;
    public bool isMirrorZ;
    public float pushPower = 2.0f;

    //gravity
    Vector3 velocity;
    bool isGrounded;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioSource jumpSound;

    public Animator animator;

    public bool movementUnlocked = true;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (isMirrorX) horizontal *= -1;
        float vertical = Input.GetAxisRaw("Vertical");
        if (isMirrorZ) vertical *= -1;
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (!movementUnlocked) direction = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("HasInput", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else animator.SetBool("HasInput", false);

        // gravity code!
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded && movementUnlocked)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpSound.Play();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // this example code was in the Unity Scripting API and it works perfectly lol
        // rigidbody pushing
        Rigidbody body = hit.collider.attachedRigidbody;
        if (!(body == null || body.isKinematic || hit.moveDirection.y < -0.3)) // makes sure the rigidbody exists, can be moved, and isn't below the player
        {
            // Calculate push direction from move direction,
            // we only push objects to the sides never up and down
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // If you know how fast your character is trying to move,
            // then you can also multiply the push velocity by that.

            // Apply the push
            body.linearVelocity = pushDir * pushPower;
        }
    }
}
