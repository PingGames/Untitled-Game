using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _horizontal;
    private float _speed = 8f;
    private float _jumpingPower = 16f;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
        }

        if (Input.GetButtonDown("Jump") && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * _speed, _rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
}
