using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class SubmitButton : MonoBehaviour
{

    [SerializeField] AudioClip error;
    [SerializeField] List<AudioClip> flavorSpeak;
    [SerializeField] List<string> flavorText;
    [SerializeField] List <string> promptText;
    //use {replace} to mark where text will be replaced
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text inputText;
    [SerializeField] TMP_Text flavorTextbox;
    [SerializeField] TMP_Text placeholderTextbox;
    [SerializeField] int page = 0;
    int max_page;
    [SerializeField] float secondsDelay;
    [Header("Game Objects")]
    [SerializeField] GameObject inputObj;

    private AudioSource audioSource;
    private bool done;


    private void Awake()
    {
        max_page = flavorSpeak.Count - 1;
        audioSource = GetComponent<AudioSource>();
    }

    public void Proceed()
    {

        if (done) return;


        if (inputText.text.Length <= 1)
        {

            flavorTextbox.text = "Awkward! We're gonna need a little more than that friend!";

            return;

        }

        page += 1;
        if (page >= max_page)
        { 
            Complete();
            return;
        }

        audioSource.PlayOneShot(flavorSpeak[page]);

        string trueText = flavorText[page].Replace("{replace}",inputText.text);

        flavorTextbox.text = trueText;

        inputField.text = "";
        placeholderTextbox.text = promptText[page];

    }

    private void Complete()
    {

        if (done) return;

        done = true;

        audioSource.PlayOneShot(flavorSpeak[page]);
        
        flavorTextbox.text = "Radical Spouse! Expect delivery soon!";

        inputField.text = "";
        inputObj.SetActive(false);

        StartCoroutine(NextScreen());

    }

    IEnumerator NextScreen()
    {

        yield return new WaitForSeconds(secondsDelay);

        flavorTextbox.text = "[ERROR (Code : GreedyBoy) : ONE ORDER PER PERSON]";
        audioSource.PlayOneShot(error);

        yield return new WaitForSeconds(secondsDelay + 0.5f);

        SceneManager.LoadScene("Scene");

    }

}
