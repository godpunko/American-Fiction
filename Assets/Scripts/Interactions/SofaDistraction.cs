using UnityEngine;
using System.Collections;

public class SofaDistraction : InteractionBase
{
    [SerializeField] Follow greg;
    [SerializeField] float distractLength;
    [SerializeField] TV tv;

    public override void Interact()
    {

        tv.Play();

        greg.SetDistraction(distractLength);
        greg.AdjustTarget(tv.gameObject, 150, 50);

        player.transform.LookAt(tv.transform.position);

        StartCoroutine(Lockout());

    }

    IEnumerator Lockout()
    {

        player.locked = true;
        yield return new WaitForSeconds(1);
        player.locked = false;

    }

}
