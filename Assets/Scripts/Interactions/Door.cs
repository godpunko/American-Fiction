using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractionBase
{

    [SerializeField] string toScene;

    public override void Interact()
    {
        SceneManager.LoadScene(toScene);
    }


}
