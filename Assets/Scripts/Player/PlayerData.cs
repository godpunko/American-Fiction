using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public bool hasKey = false;
    public bool hasWallet = false;

    PlayerData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
