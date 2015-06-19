using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public AudioClip hit;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 2);


	}
	
	// Update is called once per frame
	void Update () {

	}

	// Use if Enemy Collider is not a Trigger
	void OnCollisionEnter2D(Collision2D c)
	{
		// Check if its an enemy or thing to destroy
		if (c.gameObject.tag == "Enemy") {
			SoundManager.instance.PlaySingle(hit);
			Destroy(c.gameObject);	// Destroy object Projectile collides with
			Destroy(gameObject);	// Destroy Projectile
		}
		if (c.gameObject.tag == "Boss") {
			SoundManager.instance.PlaySingle(hit);
			Destroy(gameObject);	// Destroy Projectile
		}
	}

	// Use if Enemy Collider is a Trigger
	void OnTriggerEnter2D(Collider2D c)
	{
		// Check if its an enemy or thing to destroy
		if (c.gameObject.tag == "Enemy") {
			SoundManager.instance.PlaySingle(hit);
			Destroy(c.gameObject);	// Destroy object Projectile collides with
			Destroy(gameObject);	// Destroy Projectile
		}
		if (c.gameObject.tag == "Boss") {
			SoundManager.instance.PlaySingle(hit);
			Destroy(gameObject);	// Destroy Projectile
		}
	}
}
