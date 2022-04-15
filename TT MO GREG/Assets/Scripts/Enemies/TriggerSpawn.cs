using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
	public Spawner script;
	public int collCount;
	private float increment;

	private void Start()
	{
		collCount = 0;
		increment = .1f;
	}
	
    private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Owner")) 
		{
			collCount++;
			script.spawnToggle = true;
			if(collCount == 3)
			{
				script.spawnRange = true;
			}
			if(collCount >= 5)
			{
				script.spawnMostWait = script.spawnMostWait - .1f;
				script.spawnLeastWait = script.spawnLeastWait - .05f;
				Debug.Log("most" + script.spawnMostWait);
				Debug.Log("least" + script.spawnLeastWait);			
			}
		}
	}
}
