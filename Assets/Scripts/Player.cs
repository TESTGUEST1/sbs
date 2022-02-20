using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidBody;
    public float speed = 5f;

    void Update()
    {
        int moveX = (int)Input.GetAxisRaw("Horizontal");
        int moveY = (int)Input.GetAxisRaw("Vertical");

        animator.SetInteger("moveX", moveX);
        animator.SetInteger("moveY", moveY);

        rigidBody.velocity = new Vector2(moveX, moveY).normalized * speed;
    }
}
