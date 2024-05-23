using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 0.00000001f;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        orientation = transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Debug.Log($"{moveDirection.normalized}");
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward;

        transform.position = transform.position + Camera.main.transform.forward * moveSpeed * Time.deltaTime * verticalInput + Camera.main.transform.right * moveSpeed * horizontalInput * Time.deltaTime;

        //transform.Translate(moveDirection.normalized * moveSpeed * Time.deltaTime);

        //rb.velocity = moveDirection.normalized * moveSpeed;
    }
}
