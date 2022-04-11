using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("hit");
	}
}