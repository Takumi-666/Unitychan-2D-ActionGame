using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Player movement
        float x = 0f;
        if (Input.GetKey(KeyCode.A)) // Left movement with 'A'
        {
            x = -1f;
            Debug.Log("左");
        }
        else if (Input.GetKey(KeyCode.D)) // Right movement with 'D'
        {
            x = 1f;
            Debug.Log("→");
        }
        rb.velocity = new Vector2(x * 8f, rb.velocity.y);

        // Jump handling
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            isJump = true;
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            Debug.Log("Jumping");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
        if (collision.gameObject.CompareTag("Goal"))
        {

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }
}
