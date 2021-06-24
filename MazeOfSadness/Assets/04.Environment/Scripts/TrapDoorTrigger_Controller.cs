using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorTrigger_Controller : MonoBehaviour
{
    public List<GameObject> trapDoor;
    Animator triggerAnimator;

    private void Start()
    {
        triggerAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerAnimator.SetBool("isStamped", true);
        }

        foreach (var door in trapDoor)
        {
            Destroy(door);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerAnimator.SetBool("isStamped", false);
        }
    }
}
