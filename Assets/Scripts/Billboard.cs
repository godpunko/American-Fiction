using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private PlayerControl player;

    private void Update()
    {

        transform.LookAt(player.transform.position);

        transform.Rotate(0, 180, 0);

    }

}
