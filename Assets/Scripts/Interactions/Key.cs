using UnityEngine;

public class Key : InteractionBase
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] PlayerData playerData;

    public override void Interact()
    {

        audioSource.Play();

        playerData.hasKey = true;
        Debug.Log("Key Aquired");

        doInteract = false;
        eObject.SetActive(false);

        Destroy(gameObject);

    }
    
}
