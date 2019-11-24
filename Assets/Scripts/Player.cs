using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float MoveSpeed = 10f;
	[SerializeField] float Padding = 1f;
	[SerializeField] GameObject LaserPrefab;
	[SerializeField] float ProjectileSpeed = 10f;
	[SerializeField] float ProjectileCooldown = 0.2f;

	private float _xMin;
	private float _xMax;
	private float _yMin;
	private float _yMax;

	private Coroutine _firingCoroutine;

	// Start is called before the first frame update
	void Start()
	{
		SetupMoveBoundaries();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
		Fire();
	}

	private void Fire()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			_firingCoroutine = StartCoroutine(FireContinuously());
		}
		if (Input.GetButtonUp("Fire1"))
		{
			StopCoroutine(_firingCoroutine);
		}
	}

	private IEnumerator FireContinuously()
	{
		while (true)
		{
			var projectile = Instantiate(LaserPrefab, this.transform.position, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = Vector2.up * ProjectileSpeed;
			yield return new WaitForSeconds(ProjectileCooldown);
		}
	}

	private void SetupMoveBoundaries()
	{
		var camera = Camera.main;
		_xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
		_xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
		_yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Padding;
		_yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Padding;
	}

	private void Move()
	{
		var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed;
		var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed;

		var newXPos = Mathf.Clamp(this.transform.position.x + deltaX, _xMin, _xMax);
		var newYPos = Mathf.Clamp(this.transform.position.y + deltaY, _yMin, _yMax);

		this.transform.position = new Vector2(newXPos, newYPos);
	}
}
