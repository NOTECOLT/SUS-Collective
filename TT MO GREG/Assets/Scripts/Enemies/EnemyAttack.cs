using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	private float timeBtwShots;
	[SerializeField] private float startTimeBtwShots;

	[SerializeField] private GameObject projectile;
	[SerializeField] private GameObject slash;
	[SerializeField] private GameObject lash;
	[SerializeField] private Transform target;

	[SerializeField] private float atkRange;
	[SerializeField] private float atkDuration = 0.15f;
	[SerializeField] private string enemyType;
	private EnemyAnim _enemAnim;
	private float _atkAng;

	private void Start()
	{
		_enemAnim = GetComponent<EnemyAnim>();
		timeBtwShots = startTimeBtwShots;
		switch (enemyType) {
			case "melee":
				atkRange = 1;
				break;
			case "range":
				atkRange = 3;
				break;
			case "tentacle":
				atkRange = 2;
				break;
			default:
				atkRange = 1;
				break;
		}
	}

	private void Update() {
		if (enemyType == "melee") {
			Vector2 velocity = _enemAnim.velocity;
			_atkAng = (float)(Mathf.Atan2(velocity.y, velocity.x) * 180 / Mathf.PI) + 180;
		}

		if (Vector3.Distance(target.transform.position, transform.position) < atkRange) {
			Attack();
		}
	}

	private void Attack()
	{
		if(timeBtwShots <= 0)
		{
			timeBtwShots = startTimeBtwShots;
			if (enemyType == "melee" || enemyType == "range")
				_enemAnim.DoAttackAnim();
			else {
				GameObject lashObj = Instantiate(lash, transform.position, transform.rotation);
				lashObj.GetComponent<EnemyLash>().atkDuration = atkDuration;
			}
		}
		else
		{
			timeBtwShots -= Time.deltaTime;
		}
	}

	// Will be called in through the animation itself
	public void SpawnProj() {
		if (enemyType == "melee"){
			GameObject slashObj = Instantiate(slash, target.transform.position, Quaternion.Euler(0, 0, _atkAng));
			slashObj.GetComponent<EnemySlash>().atkDuration = atkDuration;
		} else if (enemyType == "range") {
			Instantiate(projectile, transform.position, Quaternion.identity);
		}
	}
}
