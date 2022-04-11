using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour {
    // Private Variables
    [SerializeField] private GameObject _playerAttackObj;
    private bool _isAttacking = false;
    private float _attackTimer = 0.0f;

    // Public Variables
    public float attackTime = 0.3f;
    public float attackDistance = 0.6f;
    void Start() {
        if (_playerAttackObj == null)
            Debug.LogError("No Player Attack Child Object assigned to this field!", this);
        
        SetAttackState();
    }

    void Update() {
        SetPlayerAttackRotation();
        AttackInput();
    }

    // Gets input for Player Attack Object and sets an appropriate rotation + position relative to the player
    private void SetPlayerAttackRotation() {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        double angleRad = Math.Atan2(input.y, input.x);
        float angleDeg = (float)(angleRad * 180 / Math.PI);
        
        // Sets the position & angle of the attack relative to the player
        _playerAttackObj.transform.rotation = Quaternion.Euler(-30, 0, angleDeg);
        _playerAttackObj.transform.localPosition = attackDistance * (new Vector3((float)Math.Cos(angleRad), (float)Math.Sin(angleRad), 0));
    }

    // For Detecting Attack Input
    private void AttackInput() {
        if (Input.GetKeyUp(KeyCode.J) && !_isAttacking) {
            SetAttackState(true);
        }

        if (_isAttacking) _attackTimer += Time.deltaTime;

        if (_attackTimer >= attackTime && _isAttacking) {
            SetAttackState();
        }
    }

    // Either Resets or Sets the attack state and any related variables. False by default.
    private void SetAttackState(bool state = false) {
        _isAttacking = state;
        _playerAttackObj.SetActive(state);
        if (!state) _attackTimer = 0.0f;
    }
}
