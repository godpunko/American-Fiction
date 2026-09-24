using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Follow : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;
    [SerializeField] float maxDist = 300;
    [SerializeField] PlayerControl player;
    [SerializeField] GameObject target;

    [SerializeField] NavMeshAgent self;

    bool distracted;
    public int sad;

    private void Awake()
    {

        self.speed = moveSpeed;
        self.stoppingDistance = maxDist;

        target = player.gameObject;

    }

    private void Update()
    {

        if (distracted) { return; }

        self.SetDestination(target.transform.position);

    }

    public void AdjustTarget(GameObject targ, float maxD, float speed)
    {

        target = targ;
        maxDist = maxD;
        moveSpeed = speed;

    }

    public void SetDistraction(float time)
    {

        distracted = true;
        StartCoroutine(distract(time));

    }

    IEnumerator distract(float time)
    {

        float timePassed = 0f;

        while(timePassed < time)
        {

            timePassed += Time.deltaTime;

            float passPerc = timePassed / time;
            //pie chart above head

            yield return null;
        }

        distracted = false;

    }


}
