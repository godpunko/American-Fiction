using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public float lookSpeed = 5;
    public bool hasKey = false;
    public bool hasWallet = false;
    public int gregSad;

    public static PlayerData instance;

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
