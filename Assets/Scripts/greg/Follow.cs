using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float maxDist = 300;
    [SerializeField] PlayerControl player;

    [SerializeField] NavMeshAgent self;

    private void Awake()
    {

        self.speed = moveSpeed;
        self.stoppingDistance = maxDist;

    }

    private void Update()
    {

        self.SetDestination(player.transform.position);

    }

    public void AdjustSpeed(float speed)
    {

        moveSpeed += speed;
        self.speed = moveSpeed;

    }


}
