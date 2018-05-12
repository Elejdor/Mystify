using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField]
    Transform _downRay;
    Vector2 _dir;

    float _groundCheckDist;
    float _walkForce = 20.0f;
    float _jumpForce = 10.0f;

    bool _jumpReady = true;
    bool _canJump = false;
    bool _grounded = false;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheckDist = _downRay.localPosition.magnitude;
    }

    private void FixedUpdate()
    {
        Walk();
        RefreshJump();
    }

    void RefreshJump()
    {
        if (_jumpReady)
        {
            _grounded = CheckGrounded();
            _canJump = _grounded;
        }
    }

    void Walk()
    {
        if ( _dir.Equals( Vector2.zero ) )
            return;

        _rb.AddForce( _dir * _walkForce );
        _dir = Vector2.zero;
    }

    public void handleInput(InputManager input)
    {
        _dir.x = input._horizontal;
        if (input._jump == ButtonState.Pressed)
        {
            TryJump();
        }
    }

    void TryJump()
    {
        if (_canJump)
        {
            _rb.AddForce( Vector2.up * _jumpForce, ForceMode2D.Impulse );
            _jumpReady = false;
            _canJump = false;
            StartCoroutine( Jumping() );
        }
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds( 0.1f );
        _jumpReady = true;
    }

    bool CheckGrounded()
    {
        int layer = 1 << LayerMask.NameToLayer( "Ground" );
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, _groundCheckDist, layer);
        Debug.DrawRay( transform.position, Vector2.down, Color.red, _groundCheckDist );
        if ( hit.Length > 0 )
        {
            return true;
        }

        return false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
