using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLash : MonoBehaviour
{
    public float atkDuration;
	private float _timer = 0.0f;

	void Start() {
		_timer = 0.0f;
	}

	void Update() {
		_timer += Time.deltaTime;
		//Debug.Log(_timer);

		if (_timer >= atkDuration) {
			//Debug.Log("tentacle miss!");
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Owner")
		{
			//Debug.Log("tentacle hit!");
			Destroy(gameObject);
		}
	}
}
