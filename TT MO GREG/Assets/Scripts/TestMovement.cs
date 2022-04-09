using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {
    // [Code from Help Me Find My Doll! lol]

    // Private Variables
    private float _deltaX;
    private float _deltaY;
    private Rigidbody2D _rb;

    // Public Variables
    public float playerMoveSpeed = 5.0f;
    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Moves player
        _deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerMoveSpeed;
        _deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * playerMoveSpeed;

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1f);
        _rb.velocity = input * Time.deltaTime * playerMoveSpeed * 50;
    }
}
