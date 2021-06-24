using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    private void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
