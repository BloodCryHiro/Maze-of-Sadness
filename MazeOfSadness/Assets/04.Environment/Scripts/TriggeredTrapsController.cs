using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredTrapsController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Theseus").GetComponent<Character_Controller>().health -= 1;
    }
}
