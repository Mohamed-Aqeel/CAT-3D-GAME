using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed = 12f;
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    [SerializeField] AudioSource WalkSound;

    public Vector3 Velocity;
    bool IsGrounded;
    // Update is called once per frame
    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown("w"))
        {
            WalkSound.Play();
        }

        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * Speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
        }

        Velocity.y += Gravity * Time.deltaTime;

        Controller.Move(Velocity * Time.deltaTime);
    }
}
