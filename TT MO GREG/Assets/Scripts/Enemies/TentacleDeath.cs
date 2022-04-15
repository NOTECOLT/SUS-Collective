using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleDeath : MonoBehaviour
{
	[SerializeField] private bool hitToggle;
	private Vector3 hideSpot;
	[SerializeField] private float hideSpotDis;
	private Vector3 spawnSpot;
	[SerializeField] private float moveSpeed;
	private int hitsTaken;
	[SerializeField] private EnemyAttack atkToggle;
	

	private void Start()
	{
		//Debug.Log("start death");
		hideSpot = new Vector3(transform.position.x, transform.position.y, transform.position.z + hideSpotDis);
		spawnSpot = new Vector3(transform.position.x, transform.position.y, transform.position.z); //probably just transform.position tbh but :shrug:
		hitsTaken = 0;
	}

	private void Update()
	{
		if(hitToggle == true && Vector3.Distance(transform.position, hideSpot) != 0)
		{
			//Debug.Log("goin down down");
			gameObject.layer = 3;
			transform.position = Vector3.MoveTowards(transform.position, hideSpot, moveSpeed * Time.deltaTime);
		}
		if(Vector3.Distance(transform.position, hideSpot) == 0)
		{
			//Debug.Log("okay now what");
			hitToggle = false;
		}
		if(hitToggle == false && Vector3.Distance(transform.position, spawnSpot) != 0)
		{
			//Debug.Log("up up here we go go");
			transform.position = Vector3.MoveTowards(transform.position, spawnSpot, moveSpeed * Time.deltaTime);
		}
		if(Vector3.Distance(transform.position, spawnSpot) == 0 && atkToggle.enabled == false)
		{
			//Debug.Log("back to the grind");
			gameObject.layer = 10;
			atkToggle.enabled = true;
		}

	}
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player Attack"))
		{
			//Debug.Log("ouchie");
			hitsTaken++;
			if(hitsTaken == 2)
			{
				hitToggle = true;
				hitsTaken = 0;
				atkToggle.enabled = false;
			}			
		}
	}
}
