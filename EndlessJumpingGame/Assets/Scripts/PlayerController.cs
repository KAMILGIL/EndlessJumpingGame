using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, horizontalSpeed, jumpForce, gravityScale;
    private CharacterController characterContoroller;

    private Vector3 moveDirection = Vector3.zero;

    public GameObject platformPrefab;


    private void Start()
    {
        characterContoroller = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            moveDirection = Vector3.zero;
            characterContoroller.Move(Vector3.up * 1.6f - transform.position);
            return; 
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * Mathf.Sqrt(2) * horizontalSpeed, moveDirection.y, Input.GetAxis("Horizontal") * Mathf.Sqrt(2) * horizontalSpeed);
        moveDirection += (Vector3.forward + Vector3.left) * Mathf.Sqrt(2) * speed;

        if (characterContoroller.isGrounded)
        {
            //if (Input.GetButtonDown("Jump"))
            //{
                moveDirection.y = jumpForce;
            //}
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale); 

        characterContoroller.Move(moveDirection * Time.deltaTime);
    }

    private void CreatePlatform() // then it will set skin for platforms 
    {
        float landingTime = jumpForce * jumpForce / (2 * Physics.gravity.y * gravityScale);

        float defTime = Random.Range(landingTime / 2, landingTime);
    }
}