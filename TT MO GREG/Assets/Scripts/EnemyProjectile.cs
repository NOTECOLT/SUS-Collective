using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
	[SerializeField] private GameObject target;
	private Vector2 moveDirection;
	private Rigidbody2D rb;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		//Destroy(gameObject, .1f);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Owner")
		{
			Debug.Log("ranged hit!");
			Destroy(gameObject);
		}
	}
}
