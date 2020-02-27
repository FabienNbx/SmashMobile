using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    [HideInInspector]
    public int look = 1; // 1 : regarde a droite, -1 à gauche

    private PlayerInput inputs;
    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        inputs = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        if(inputs.jump && !isJumping)
            jump();

        if (isJumping)
            checkStopJump();
    }

    private void move()
    {
        Vector3 movement = new Vector3(inputs.direction,0,0);
        transform.Translate(movement * speed * Time.deltaTime);
        look = inputs.direction != 0 ? inputs.direction : look;
    }

    private void jump()
    {
        isJumping = true;
        rb.velocity = new Vector2(0, jumpForce);
    }

    private void checkStopJump()
    {
        if (rb.velocity == Vector2.zero)
        {
            isJumping = false;
        }
    }
}
