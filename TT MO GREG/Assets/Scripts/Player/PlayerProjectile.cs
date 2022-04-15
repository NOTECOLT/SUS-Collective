using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {
    // Private Variables
    [SerializeField] private float _speed;

    // Public Variables
	public Vector2 target;
    public float targetAngle;

    private Vector2 _prevPos;

    private void Start() {
        _prevPos = transform.position;
        float angRad = targetAngle / 180 * Mathf.PI;
        target = (Vector2)transform.position - (new Vector2((float)Mathf.Cos(angRad), (float)Mathf.Sin(angRad)) * 3);
    }

	private void FixedUpdate() {
		transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
		if(transform.position.x == target.x && transform.position.y == target.y) {
			DestroyProjectile();
		}
	}

	private void DestroyProjectile() {
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other) {
        DestroyProjectile();
	}
}
