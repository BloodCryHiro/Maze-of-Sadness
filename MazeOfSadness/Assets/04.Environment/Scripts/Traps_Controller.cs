using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps_Controller : MonoBehaviour
{
    Animator animator;

    public GameObject player;
    private float damageTimer;
    
    private float timer;

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void TrapsTrigger()
    {
        animator.SetBool("isStamped", true);
    }

    private void TrapsTriggerRevert()
    {
        animator.SetBool("isStamped", false);
    }

    private void TimerStart()
    {
        timer += 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = 0f;
        InvokeRepeating("TimerStart", 0f, 0.5f); 
        Invoke("TrapsTrigger", 0.5f);
        Invoke("TrapsTriggerRevert", 1.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timer >= 1f && timer <= 1.5f && damageTimer >= 5f)
        {
            player.GetComponent<Character_Controller>().health -= 1;
            damageTimer = 0f;
        }
    }
}
