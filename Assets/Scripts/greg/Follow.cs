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
    [SerializeField] float distractRunSpeed = 40;

    bool distracted;
    public int sad;

    private void Awake()
    {

        self.speed = moveSpeed;
        self.stoppingDistance = maxDist;

        target = player.gameObject;

    }

    private void Start()
    {

        sad = PlayerData.instance.gregSad;
        moveSpeed += sad;
        maxDist -= (sad * 5);
        if(maxDist< 50) maxDist = 50;

    }

    private void Update()
    {

        if (distracted) { return; }

        self.SetDestination(target.transform.position);

    }

    public void UpdateSad(int sadness)
    {

        sad += sadness;
        PlayerData.instance.gregSad = sad;
        moveSpeed = 5 + sad;
        maxDist -= 5;
        if (maxDist < 50) maxDist = 50;

        self.speed = moveSpeed;
        self.stoppingDistance = maxDist;

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
