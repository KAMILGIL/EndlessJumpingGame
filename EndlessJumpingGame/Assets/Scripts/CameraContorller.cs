using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContorller : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset; 

    private void Start()
    {
        transform.LookAt(player.transform);
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position += (- transform.position + player.transform.position + offset) * Time.deltaTime * 4;
    }
}
