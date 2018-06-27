using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField]
    Transform _downRay;
    Vector2 _dir;

    [SerializeField]
    Transform _crossHair;       

    [SerializeField]
    Animator _anim;

    [SerializeField]
    Transform _renderer;

    Anima2D.PoseManager _poseManager;
    SoundManager _sound;

    float _groundCheckDist;
    float _walkForce = 8.0f;
    float _jumpForce = 1200.0f;
    float _flipValue = 1f;

    bool _jumpReady = true;
    bool _canJump = false;
    bool _grounded = false;
    bool _isLeft = true;

    void Start()
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
            _anim.SetBool( "grounded", _grounded );
            _canJump = _grounded;
        }
    }

    void Walk()
    {            
        if( (this.transform.position.x > _crossHair.transform.position.x) && _isLeft)
        {
            Flip();
            _flipValue = 1f;
        }
        else if( (this.transform.position.x < _crossHair.transform.position.x) && !_isLeft)
        {
            Flip();
            _flipValue = -1f;
        }

        _anim.SetFloat("dirParameter", _dir.x * _flipValue);           

        _rb.velocity = new Vector2( _dir.x * _walkForce, _rb.velocity.y );
    }

    public void handleInput(InputManager input)
    {
        _dir.x = input._horizontal;

        _anim.SetFloat( "Speed", Mathf.Abs( _dir.x ) );
        _anim.SetFloat( "VerticalSpeed", _rb.velocity.y );      

        if (input._jump == ButtonState.Pressed)
        {
            TryJump();
        }
    }

    void TryJump()
    {
        if (_canJump)
        {
            _rb.AddForce( Vector2.up * _jumpForce );
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
        Debug.DrawRay(transform.position, Vector2.down, Color.red, _groundCheckDist );
        if ( hit.Length > 0 )
        {
            return true;
        }      

        return false;
    }

    void Flip()
    {
        _isLeft = !_isLeft;
        Vector3 scale = _renderer.localScale;
        scale.x *= -1;
        _renderer.localScale = scale;
    }
}
