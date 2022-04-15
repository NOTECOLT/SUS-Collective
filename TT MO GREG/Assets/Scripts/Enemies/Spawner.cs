using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
	//[SerializeField] private Vector3 spawnValues;
	[SerializeField] private float spawnWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public float startWait;
	[SerializeField] private GameObject parent;
	[SerializeField] private GameObject[] spawnPoints;
	public bool spawnToggle;
	public bool spawnRange;
	private bool spawning;

	private int randEnemy;
	private int randomizer;
	private int randPoint;

    private void Start()
    {
        StartCoroutine(waitSpawner());
		spawnToggle = false;
		spawnRange = false;
    }

    void Update()
    {
		randEnemy = Random.Range(0, enemies.Length);
		randPoint = Random.Range(0, spawnPoints.Length);
		spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
		if(spawnToggle == true && spawning == false)
		{
			spawning = true;
			StartCoroutine(waitSpawner());
		}
		if(spawnToggle == false)
		{
			spawning = false;
		}
    }

	IEnumerator waitSpawner()
	{
		yield
		return new WaitForSeconds(startWait);

		while(spawning)
		{
			if(spawnRange == true)
			{
				Debug.Log("range spawn");
				GameObject enemy = Instantiate(enemies[randEnemy], spawnPoints[randPoint].transform.position, enemies[randEnemy].transform.rotation);
				enemy.transform.SetParent(parent.transform);	
			}
			else
			{
				Debug.Log("melee only spawn");
				GameObject enemy = Instantiate(enemies[0], spawnPoints[randPoint].transform.position, enemies[0].transform.rotation);
				enemy.transform.SetParent(parent.transform);

			}
			
			yield
			return new WaitForSeconds(spawnWait);
		}

	}
}
