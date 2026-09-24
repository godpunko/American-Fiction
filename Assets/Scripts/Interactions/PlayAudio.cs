using UnityEngine;

public class PlayAudio : InteractionBase
{

    [SerializeField] AudioSource audioSource;

    public override void Interact()
    {
    
        if(!audioSource.isPlaying)
        {

            audioSource.Play();

        }
        else
        {

            audioSource.Stop();

        }

    
    }
    
}
