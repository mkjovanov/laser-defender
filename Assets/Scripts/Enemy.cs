using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Main stats")]
	[SerializeField] int Health = 100;

	[Header("Cooldowns")]
	[SerializeField] float ShotCooldown;
	[SerializeField] float MinShotCooldown = 0.2f;
	[SerializeField] float MaxShotCooldown = 3f;

	[Header("Projectile info")]
	[SerializeField] GameObject Projectile;
	[SerializeField] float ProjectileSpeed = 10f;
	[SerializeField] bool IsShooting = true;

	void Start()
	{
		ShotCooldown = UnityEngine.Random.Range(MinShotCooldown, MaxShotCooldown);
		StartCoroutine(ShootContinuously());
	}

	private IEnumerator ShootContinuously()
	{
		//ShotCooldown -= Time.deltaTime;
		while (true)
		{
			var projectile = Instantiate(Projectile, this.gameObject.transform.position, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * ProjectileSpeed;
			yield return new WaitForSeconds(ShotCooldown);
			ShotCooldown = UnityEngine.Random.Range(MinShotCooldown, MaxShotCooldown);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		var damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if (damageDealer != null)
		{
			ProcessHit(damageDealer);
		}
	}

	private void ProcessHit(DamageDealer damageDealer)
	{
		this.Health -= damageDealer.GetDamage();
		if (this.Health <= 0)
		{
			Destroy(this.gameObject);
		}
	}
}
