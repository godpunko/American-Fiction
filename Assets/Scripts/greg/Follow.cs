using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

public class Follow : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float maxDist = 300;
    [SerializeField] PlayerControl player;
    [SerializeField] GameObject target;

    [SerializeField] NavMeshAgent self;
    [SerializeField] float distractRunSpeed = 150;
    [SerializeField] GameObject distractionCanvas;
    [SerializeField] Image distractionImage;
    [SerializeField] bool rabid;

    public bool distracted;
    public int sad;

    private void Awake()
    {

        self.speed = moveSpeed;
        self.stoppingDistance = maxDist;

        //yes spaghetti
        if(rabid)
        {

            self.speed = 200;
            self.acceleration = 200;
            self.stoppingDistance = 0;

        }

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

        if (!distracted) sad += 10;

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
        self.speed = speed;
        self.acceleration = speed;
        self.stoppingDistance = maxD;
        self.SetDestination(target.transform.position);

    }

    public void SetDistraction(float time)
    {
        
        StartCoroutine(distract(time));

    }

    IEnumerator distract(float time)
    {

        distracted = true;
        distractionCanvas.SetActive(true);

        float timePassed = 0f;

        while(timePassed < time)
        {

            timePassed += Time.deltaTime;

            float passPerc = timePassed / time;
            distractionImage.fillAmount = 1 - passPerc;

            yield return null;
        }

        AdjustTarget(player.gameObject, maxDist, moveSpeed);
        distractionCanvas.SetActive(false);
        distracted = false;

        if(Vector3.Distance(transform.position,player.transform.position) > 100) UpdateSad(0);

    }


}
