using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private string enemyType;
	[SerializeField] private GameObject bullet;
	private float attackDistance;

	private void Start() //check monster type
	{
		if (enemyType == "melee")
		{
			attackDistance = 1;
		}
		else if (enemyType == "range")
		{
			attackDistance = 4;
		}
		StartCoroutine("Reset");
	}

	IEnumerator Reset()
	{
		if (Vector2.Distance(transform.position, target.position) < attackDistance) //if target is within attack distance, attack
		{
			Attack();
		}
		yield return new WaitForSeconds(2); //2s interval before next attack
		StartCoroutine("Reset"); //restart attack sequence
	}

	private void Attack()
	{
		if (enemyType == "melee")
		{
			Debug.Log("melee hit!"); //melee anim + whatever the melee does to owner/player
		}
		else if (enemyType == "range")
		{
			Instantiate (bullet, transform.position, Quaternion.identity);
		}
	}
}
