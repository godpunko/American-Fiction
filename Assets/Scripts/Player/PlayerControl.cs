using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    private PlayerInput input;
    [SerializeField] CamCursor cam;
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float sprintSpeed = 10;
    float moveSpeed;
    float rotationY = 0f;
    Rigidbody rb;
    AudioSource audioSource;
    int stepCount = 0;


    private void Awake()
    {
        input = new PlayerInput();
        moveSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if (input.player.Sprint.IsPressed()) moveSpeed = sprintSpeed;
        else moveSpeed = walkSpeed;

        LookHorizontal();
        Move();
    }

    private void LookHorizontal()
    {

        if (!cam.canLook) return;

        Vector2 mouseRot = Mouse.current.delta.ReadValue();

        float mouseX = mouseRot.x * cam.lookSpeed * Time.deltaTime;

        rotationY += mouseX;

        transform.localRotation = Quaternion.Euler(0, rotationY, 0);

    }

    private void Move()
    {

        if (!cam.canLook) return;

        Vector2 movement = input.player.Move.ReadValue<Vector2>();

        stepCount++;
        if (movement == Vector2.zero) stepCount = 0;
        if(stepCount == 1) audioSource.Play();
        if (stepCount >= 550 - moveSpeed) stepCount = 0;

        Vector3 newMovement = transform.right * movement.x + transform.forward * movement.y;

        newMovement.y = 0f;

        rb.linearVelocity = newMovement * moveSpeed;

    }

}
