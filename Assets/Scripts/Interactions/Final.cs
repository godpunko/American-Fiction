using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Final : InteractionBase
{

    AudioSource audioSource;
    [SerializeField] string finalPlace;
    [SerializeField] AudioClip good;

    public override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {

        if(PlayerData.instance.hasKey &&  PlayerData.instance.hasWallet)
        {

            audioSource.PlayOneShot(good);
            StartCoroutine(FinalLoad());

        }
        else
        {

            audioSource.Play();

        }

    }

    IEnumerator FinalLoad()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(finalPlace);

    }

}
