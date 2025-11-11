using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControllerCharacter : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Transform cameraTransform;

    private int count;
    private Vector2 movement;
    public float speed = 5f;
    public float dashSpeed = 35f;
    public float dashDuration = 0.6f;
    public float dashCooldown = 0.8f;
    public float rotationSpeed = 10f;
    public float jumpHeight = 2f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Transform modelTransform;

    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    private bool isJumping = false;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float lastDashTime = -1f;
    private Vector3 dashDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;

        if (modelTransform == null && animator != null)
            modelTransform = animator.transform;

        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        controller.slopeLimit = 60f;
        controller.stepOffset = 0.5f;
    }

    void Update()
    {
        Vector3 move = cameraTransform.forward * movement.y + cameraTransform.right * movement.x;
        move.y = 0f;

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);

            if (dashTimer <= 0f)
            {
                isDashing = false;
            }
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (controller.isGrounded)
        {
            if (isJumping && playerVelocity.y < 0)
                isJumping = false;
            playerVelocity.y = -1f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        bool isMoving = move.magnitude > 0.1f;
        animator.SetBool("isWalking", isMoving);

        if (isMoving && modelTransform != null)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && controller.isGrounded)
        {
            isJumping = true;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing && Time.time > lastDashTime + dashCooldown)
        {
            Vector3 move = cameraTransform.forward * movement.y + cameraTransform.right * movement.x;
            move.y = 0f;
            if (move.magnitude > 0.1f)
            {
                dashDirection = move.normalized;
                isDashing = true;
                dashTimer = dashDuration;
                lastDashTime = Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        Transform doorsParent = GameObject.Find("Doors").transform;

        if (count == 2)
        {
            Transform door1 = doorsParent.Find("Door1");
            if (door1 != null) door1.gameObject.SetActive(false);
        }
        if (count == 5)
        {
            Transform door2 = doorsParent.Find("Door2");
            if (door2 != null) door2.gameObject.SetActive(false);
        }
        if (count == 8)
        {
            Transform door3 = doorsParent.Find("Door3");
            if (door3 != null) door3.gameObject.SetActive(false);
        }
        if (count == 10)
        {
            Transform door4 = doorsParent.Find("Door4");
            if (door4 != null) door4.gameObject.SetActive(false);
        }
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            return;
        }

        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z).normalized;
            float pushPower = 6f;
            rb.linearVelocity = pushDir * pushPower;
        }
    }
}
