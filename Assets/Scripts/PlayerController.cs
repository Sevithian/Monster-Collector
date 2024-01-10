using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    PlayerInputs PI;
    CharacterController CC;


    private void Start()
    {
        PI = GetComponent<PlayerInputs>();
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        CC.Move(((Vector3.forward * PI.RawInput.y) + (Vector3.right * PI.RawInput.x)) * MoveSpeed * Time.fixedDeltaTime);
        if (!CC.isGrounded)
            CC.Move(Vector3.down * 5);
    }
}
