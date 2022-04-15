using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour {
    // Private Variables
    private GameStateManager _gsm;
    [SerializeField] private GameObject _playerAttackObj;
    private bool _isAttacking = false;
    private float _attackTimer = 0.0f;
    private Animator _anim;
    [SerializeField] private bool _projUnlocked = false;
    private Vector3 _attackPos;
    private float _attackAng;

    // Public Variables
    public float attackTime = 0.15f;
    public float attackDistance = 0.6f;
    public float attackCooldown = 1.0f;
    public float verticalOffset = 0;
    public GameObject projPrefab;
    public PauseMenu pm;

    void Start() {
        _projUnlocked = false;
        _anim = GetComponent<Animator>();
        _gsm = GameStateManager.Instance;

        if (_playerAttackObj == null)
            Debug.LogError("No Player Attack Child Object assigned to this field!", this);
        
        EndAttack();
    }

    void Update() {
        if (!_gsm.gameOver && !_gsm.catDie && !pm.gameIsPaused) {
            SetPlayerAttackRotation();
            AttackInput();
        }

    }

    // Gets input for Player Attack Object and sets an appropriate rotation + position relative to the player
    private void SetPlayerAttackRotation() {
        Vector2 input = (Vector2)Input.mousePosition - (new Vector2(Screen.width/2, Screen.height/2));
        double angRad = 0;

        angRad = Math.Atan2(input.y, input.x);

        _attackAng = (float)(angRad * 180 / Math.PI) + 180;
        _attackPos = new Vector3((float)Math.Cos(angRad), (float)Math.Sin(angRad) + verticalOffset, 0);
        
        // Sets the position & angle of the attack relative to the player
        _playerAttackObj.transform.rotation = Quaternion.Euler(0, 0, _attackAng);
        _playerAttackObj.transform.localPosition = attackDistance * _attackPos;
    }

    // For Detecting Attack Input
    private void AttackInput() {
        if (Input.GetMouseButtonUp(0) && _attackTimer <= 0) {
            StartAttack();
            _anim.SetTrigger("Attack");
        }

        if (_attackTimer > 0) _attackTimer -= Time.deltaTime;
        
        // Attack has finished its course
        if (_attackTimer < attackCooldown && _isAttacking)
            EndAttack();
    }

    private void StartAttack() {
        _attackTimer = attackCooldown + attackTime;

        _isAttacking = true;
        _playerAttackObj.GetComponent<BoxCollider2D>().enabled = true;   
        _anim.SetTrigger("SlashAnim");

        if (_projUnlocked) {
            GameObject proj = Instantiate(projPrefab, transform.position + (attackDistance * _attackPos), _playerAttackObj.transform.rotation);
            proj.GetComponent<PlayerProjectile>().targetAngle = _attackAng;
        }
    }

    private void EndAttack() {
        _isAttacking = false;
        _playerAttackObj.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetProjectile(bool state) {
        _projUnlocked = state;
    }
}
