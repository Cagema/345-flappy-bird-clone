using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _force;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_rb.velocity != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y);
        }

        if (transform.position.y > GameManager.Single.RightUpperCorner.y + 0.5f ||
            transform.position.y < -GameManager.Single.RightUpperCorner.y - 0.5f)
        {
            GameManager.Single.Lives--;
        }
    }

    private void Jump()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Single.Lives--;

        }
        else
        {
            GameManager.Single.Score++;
        }
    }

    public void StartFall()
    {
        _rb.gravityScale = 1;
        Jump();
    }
}
