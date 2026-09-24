using UnityEngine;
using System.Collections;

public class Key : InteractionBase
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] Follow greg;
    [SerializeField] BoxCollider bc;
    bool can = true;

    public override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        if (PlayerData.instance.hasKey) Destroy(gameObject);
    }

    public override void Interact()
    {

        if (!can) return;

        can = false;

        audioSource.Play();

        PlayerData.instance.hasKey = true;
        greg.UpdateSad(2);
        Debug.Log("Key Aquired");

        doInteract = false;
        eObject.SetActive(false);

        Destroy(bc);

        StartCoroutine(Die());

    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);

    }
    
}
