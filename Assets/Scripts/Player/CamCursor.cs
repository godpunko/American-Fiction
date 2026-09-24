using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class CamCursor : MonoBehaviour
{

    public float lookSpeed;
    [SerializeField] float lookYlim;

    private float rotationX = 0;

    private PlayerInput input;
    public bool canLook;

    [SerializeField] GameObject pause;
    [SerializeField] TMP_Text text;

    void Awake()
    {
        input = new PlayerInput();
        Cursor.lockState = CursorLockMode.Locked;
        canLook = true;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }


    void Update()
    {
       
        if(input.player.EscapeWindow.WasPressedThisFrame() && canLook) 
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canLook = false;
            pause.SetActive(true);
        }
        else if ((input.player.EscapeWindow.WasPressedThisFrame() && !canLook) || input.player.ClickBackIn.WasPressedThisFrame()) 
        { 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canLook = true;
            pause.SetActive(false);
        }

        text.text = $"LOOK SPEED\n\n{lookSpeed}";

        Look();

    }

    private void Look()
    {

        if (!canLook) return;

        Vector2 mouseRot = Mouse.current.delta.ReadValue();

        float mouseY = mouseRot.y * lookSpeed * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookYlim, lookYlim);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

    }

    public void IncreaseLookSpeed()
    {
        lookSpeed++;
        if (lookSpeed >= 20) lookSpeed = 20;
    }

    public void DecreaseLookSpeed()
    {
        lookSpeed--;
        if (lookSpeed <= 1) lookSpeed = 1;
    }

}
