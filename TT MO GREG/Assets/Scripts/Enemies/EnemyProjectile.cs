using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
	private Transform player;
	private Vector2 target;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(player.position.x, player.position.y);
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyProjectile();
		}
	}

	private void DestroyProjectile()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") || other.CompareTag("Owner"))
		{
			Debug.Log("ranged hit!");
			DestroyProjectile();
		}
		else
		{
			Debug.Log("ranged miss!");
			DestroyProjectile();
		}

	}
}
