using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour {
    private Animator _anim;
    private Vector2 _prevPos;
    public Vector2 velocity;
    void Start() {
        _anim = GetComponent<Animator>();
        _prevPos = transform.position;
    }

    void Update() {
        MovementAnims();
    }

    // Calculates the velocity of the sprite & then uses the angle to determine direction
    private void MovementAnims() {
        velocity = ((Vector2)transform.position - _prevPos) / Time.deltaTime;

        if (Mathf.Abs(velocity.x) > 0.5f || Mathf.Abs(velocity.y) > 0.5f)
            _anim.SetTrigger("Walk");
        else if (velocity.x <= 0.5f && velocity.y <= 0.5f)
            _anim.SetTrigger("Idle");

        if (velocity.x >= 0)
            _anim.SetTrigger("Right");
        else 
            _anim.SetTrigger("Left");

        _prevPos = transform.position;
    }

    public void DoAttackAnim() {
        _anim.SetTrigger("Attack");
    }
}
