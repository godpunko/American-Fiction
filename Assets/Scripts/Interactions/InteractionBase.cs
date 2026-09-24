using UnityEngine;
using TMPro;

public class InteractionBase : MonoBehaviour
{

    [SerializeField] protected string interactionLabel;
    [SerializeField] protected GameObject eObject;
    [SerializeField] protected TMP_Text interactionText;
    [SerializeField] protected PlayerControl player;
    [SerializeField] protected bool activeOnTouch = false;
    protected PlayerInput input;
    protected bool doInteract = false;


    protected void Awake()
    {
        input = new PlayerInput();
    }

    protected void OnEnable()
    {
        input.Enable();
    }

    protected void OnDisable()
    {
        input.Disable();
    }

    protected void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (activeOnTouch) 
            { 
                Interact();
                return;
            }

            doInteract = true;
            eObject.SetActive(true);
            interactionText.text = interactionLabel;

        }

    }

    protected void OnTriggerExit(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {

            doInteract = false;
            eObject.SetActive(false);

        }

    }

    protected void Update()
    {
        if(input.player.Interact.WasPressedThisFrame() && doInteract) Interact();
    }

    public virtual void Interact() { }


}
