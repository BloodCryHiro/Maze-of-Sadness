using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsController_Test : MonoBehaviour
{
    SpriteRenderer traps_UnTriggerd;
    SpriteRenderer traps_Triggerd;

    Collider2D collider_UnTriggered;
    Collider2D collider_Triggered;

    private void Start()
    {
        traps_UnTriggerd = GetComponent<SpriteRenderer>();
        traps_Triggerd = GameObject.Find("Triggered_Trap").GetComponent<SpriteRenderer>();

        collider_UnTriggered = GetComponent<Collider2D>();
        collider_Triggered = GameObject.Find("Triggered_Trap").GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TrapsTriggering());
    }

    private IEnumerator TrapsTriggering()
    {
        yield return new WaitForSeconds(0.5f);
        traps_UnTriggerd.enabled = false;
        collider_UnTriggered.enabled = false;
        traps_Triggerd.enabled = true;
        collider_Triggered.enabled = true;
        yield return new WaitForSeconds(1f);
        traps_UnTriggerd.enabled = true;
        collider_UnTriggered.enabled = true;
        traps_Triggerd.enabled = false;
        collider_Triggered.enabled = false;
    }
}
