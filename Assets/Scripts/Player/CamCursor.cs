using UnityEngine;
using UnityEngine.InputSystem;

public class CamCursor : MonoBehaviour
{

    public float lookSpeed;
    [SerializeField] float lookYlim;

    private float rotationX = 0;

    private PlayerInput input;
    public bool canLook;

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
       
        if(input.player.EscapeWindow.WasPressedThisFrame()) 
        { 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canLook = false; 
        }
        if (input.player.ClickBackIn.WasPressedThisFrame()) 
        { 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canLook = true; 
        }

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

}
