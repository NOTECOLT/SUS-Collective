using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class OwnerMovement : MonoBehaviour {
    // Private Variables
    private float _totalDistance;
    private Animator _anim;
    private Vector2 _prevPos;
    private GameStateManager _gsm;
    
    // Public Variables
    public float moveSpeed = 1.0f;
    public PathCreator pc;
    public float invMult = 1.5f;
    void Start() {
        _anim = GetComponent<Animator>();
        _prevPos = transform.position;
        _gsm = GameStateManager.Instance;
    }

    void Update() {
        if (!_gsm.gameOver) {
            Movement();
            MovementAnims();
        }
    }

    private void Movement() {
        if (GetComponent<OwnerHealth>().isInvincible)
            _totalDistance += moveSpeed * Time.deltaTime * invMult;
        else
            _totalDistance += moveSpeed * Time.deltaTime;
        transform.position = pc.path.GetPointAtDistance(_totalDistance);
    }

    // Calculates the velocity of the sprite & then uses the angle to determine direction
    private void MovementAnims() {
        Vector2 velocity = ((Vector2)transform.position - _prevPos) / Time.deltaTime; 
        float vecAng = Mathf.Atan2(velocity.y, velocity.x) * 180 / Mathf.PI;

        if (vecAng > -135 && vecAng <= -45)
            _anim.SetTrigger("Forward");
        else if (vecAng > -45 && vecAng <= 45)
            _anim.SetTrigger("Right");
        else if (vecAng > 45 && vecAng <= 135)
            _anim.SetTrigger("Backward");
        else if ((vecAng > 135 && vecAng <= 225) || (vecAng > -225 && vecAng <= -135))
            _anim.SetTrigger("Left");
        
        _prevPos = transform.position;
    }
}
