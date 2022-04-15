using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // [Code from Help Me Find My Doll! lol]

    // Private Variables
    private Rigidbody2D _rb;
    private Vector2 _walkInput;
    private Vector2 _dashInput;
    private Animator _anim;

    private float _dashTimer = 0.0f;
    private bool _isDashing = false;
    private GameStateManager _gsm;

    [SerializeField] private bool _dashUnlocked = false;

    // Public Variables
    public float moveSpeed = 5.0f;
    public float dashMultiplier = 3.0f;
    public float invMultiplier = 1.5f;
    public float dashCooldown = 0.5f;
    public float dashDuration = 0.15f;
    
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _isDashing = false;
        _dashUnlocked = false;
        _gsm = GameStateManager.Instance;
    }

    private void Update() {
        if (!_gsm.gameOver && !_gsm.catDie) {
            MoveInput();
            MovementAnims();

            if (_dashUnlocked && !GetComponent<PlayerLives>().isInvincible) DashInput();
        }
    }
    private void FixedUpdate() {
        if (!_gsm.gameOver && !_gsm.catDie) {
            if (_isDashing) // dash movement
                _rb.MovePosition((Vector2)transform.position + _dashInput * Time.deltaTime * moveSpeed * dashMultiplier);
            else if (GetComponent<PlayerLives>().isInvincible)
                _rb.MovePosition((Vector2)transform.position + _walkInput * Time.deltaTime * moveSpeed * invMultiplier);
            else          // Regular walking movement
                _rb.MovePosition((Vector2)transform.position + _walkInput * Time.deltaTime * moveSpeed);
        }
    }

    private void MoveInput() {
        _walkInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _walkInput = Vector2.ClampMagnitude(_walkInput, 1f);
    }

    private void MovementAnims() {
        _anim.SetFloat("xVec", _walkInput.x);

        if (_walkInput.x == 0 && _walkInput.y == 0)
            _anim.SetTrigger("Idle");
        else if (_walkInput.y != 0 || _walkInput.x != 0)
            _anim.SetTrigger("Walk");
    }

    // For Detecting Dash Input
    private void DashInput() {
        if (Input.GetKeyUp(KeyCode.Space) && _dashTimer <= 0 && (_walkInput.x != 0 || _walkInput.y != 0)) {
            _dashTimer = dashCooldown + dashDuration;
            _dashInput = _walkInput;
            _isDashing = true;
        }

        // Once dash timer finishes the duration, reset the move speed
        if (_dashTimer <= dashCooldown) {
            _isDashing = false;
        }

        if (_dashTimer > 0) _dashTimer -= Time.deltaTime;
    }

    public void IncrementSpeed(float inc) {
        moveSpeed += inc;
    }

    public void setDashable(bool state) {
        _dashUnlocked = state;
    }
}
