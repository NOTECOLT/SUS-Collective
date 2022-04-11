using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] private Transform target;
	[SerializeField] private string enemyType;
	private float attackDistance;

	private void Start()
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
		yield return new WaitForSeconds(2);
		StartCoroutine("Reset");
	}

	private void Attack()
	{
		if (enemyType == "melee")
		{
			Debug.Log("melee hit!");
		}
		else if (enemyType == "range")
		{
			Debug.Log("range hit!");
		}
	}
}
