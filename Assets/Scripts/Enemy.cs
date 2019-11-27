using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int Health = 100;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var damageDealer = other.gameObject.GetComponent<DamageDealer>();
		ProcessHit(damageDealer);
		
		
	}

	private void ProcessHit(DamageDealer damageDealer)
	{
		this.Health -= damageDealer.GetDamage();
		if (this.Health <= 0)
		{
			Destroy(this);
		}
	}
}
