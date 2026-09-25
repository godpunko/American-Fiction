using UnityEngine;
using System.Collections;

public class Wallet : InteractionBase
{
    //there should be a pickup subclass but w/ever

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip good;
    [SerializeField] Follow greg;
    [SerializeField] BoxCollider bc;
    bool can = true;

    public override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        if (PlayerData.instance.hasWallet) Destroy(gameObject);
    }

    public override void Interact()
    {

        if (!can) return;

        can = false;



        PlayerData.instance.hasWallet = true;
        if (!greg.distracted) { greg.UpdateSad(2); audioSource.Play(); }
        else audioSource.PlayOneShot(good);
        Debug.Log("Wallet Aquired");

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
