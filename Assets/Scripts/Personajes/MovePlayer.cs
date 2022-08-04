using System;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 6.0F;
    public float rotationSpeed = 100F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float xRotation = 0f;

    public Animator animation;
    public Transform playerBody;
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animation = GetComponent<Animator>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical1"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump1")) moveDirection.y = jumpSpeed;
        }

        float rotation = Input.GetAxis("Horizontal1") * rotationSpeed * Time.deltaTime;
        xRotation += rotation;
        animation.SetFloat("Walk", Math.Abs(moveDirection.z));

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(0f, xRotation, 0f);
    }
}