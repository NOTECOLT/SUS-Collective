using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLives : MonoBehaviour {
    // Public Variables
    public GameObject respawnPoint;
    public UnityEvent[] onDeathActions; // List containing UnityActions for what to do on each death (1 buff per death)
    private GameStateManager _gsm;
    private Animator _anim;

    public bool isInvincible = false;
    public float invDuration = 3.0f;
    private float _invTimer = 0f;
    
    void Start() {
        _gsm = GameStateManager.Instance;
        _gsm.currentLives = _gsm.totalLives;

        _anim = GetComponent<Animator>();

        if (respawnPoint == null)
            Debug.LogError("No Respawn Point Object assigned to this field!", this);
        if (_gsm == null)
            Debug.LogError("No GameStateManager object assigned to this field!", this);

        transform.position = respawnPoint.transform.position;

        isInvincible = false;
    }

    void Update() {
        if (isInvincible) {
            _invTimer -= Time.deltaTime;
            if (_invTimer <= 0) {
                isInvincible = false;
                _anim.SetTrigger("NotInv");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!_gsm.gameOver && !_gsm.catDie && !isInvincible) {
            if (other.gameObject.layer == LayerMask.NameToLayer("EnemyProjectile")) {
                if (_gsm.currentLives > 1) {
                    Die(true);
                } else if (_gsm.currentLives == 1) {
                    Die(false);
                    _gsm.TriggerGameOver();
                }
            }
        }
    }

    private void StartInvincibility() {
        isInvincible = true;
        _anim.SetTrigger("Invincible");
        _invTimer = invDuration;
    }

    private void Die(bool doRespawn) {
        _gsm.catDie = true;
        _gsm.RemoveCatLife();
        if (doRespawn)
            _anim.SetTrigger("Death");
        else
            _anim.SetTrigger("GameOver");
    }

    // Called through death animation
    public void Respawn() {
        transform.position = respawnPoint.transform.position;

        onDeathActions[_gsm.totalLives - _gsm.currentLives - 1].Invoke();
        _gsm.catDie = false;

        StartInvincibility();
    }
}
