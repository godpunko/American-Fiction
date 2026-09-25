using UnityEngine;

public class TV : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void Play()
    {

        audioSource.Play();

    }

}
