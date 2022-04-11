using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // [Code from Help Me Find My Doll! lol]

    // Private Variables
    private Rigidbody2D _rb;
    private Vector2 _input;

    // Public Variables
    public float playerMoveSpeed = 5.0f;
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _input = Vector2.ClampMagnitude(_input, 1f);
    }
    private void FixedUpdate() {
        _rb.MovePosition((Vector2)transform.position + _input * Time.deltaTime * playerMoveSpeed);
    }
}
