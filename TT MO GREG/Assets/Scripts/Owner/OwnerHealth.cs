using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerHealth : MonoBehaviour {
    private GameStateManager _gsm;
    private Animator _anim;
    public bool isInvincible = false;
    public float invDuration = 2.0f;
    private float _invTimer = 0f;
	[SerializeField] private AudioSource ownerDamaged;
	private Vector3 floatUp;
    
    void Start() {
        _gsm = GameStateManager.Instance;
        _anim = GetComponent<Animator>();
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
                if (_gsm.currentOwnerHealth > 1) {
					ownerDamaged.Play();
                    _anim.SetTrigger("Damaged");
                    _gsm.RemoveOwnerHealth();
                } else if (_gsm.currentOwnerHealth == 1) {
					//floatUp = new Vector3(transform.position.x, transform.position.y, transform.position.z - .5f);
					//transform.position = Vector3.MoveTowards(transform.position, floatUp, 1);
                    _gsm.RemoveOwnerHealth();
                    _anim.SetTrigger("Death");
                    _gsm.TriggerGameOver();
                }
            }
        }

    }

    // called through animator
    public void StartInvincibility() {
        isInvincible = true;
        _anim.SetTrigger("Invincible");
        _invTimer = invDuration;
    }

}
