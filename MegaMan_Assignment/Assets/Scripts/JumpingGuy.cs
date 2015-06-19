using UnityEngine;
using System.Collections;

public class JumpingGuy : MonoBehaviour {


	public GameObject projectile;
	public Transform projectileSpawnPoint;
	public BoxCollider2D collider;
	Rigidbody2D temp;
	bool shot = false;
	public Rigidbody2D jump;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shot == false) {
			shot = true;
			StartCoroutine (pause ());
		}
	}

	IEnumerator pause() {
		
		yield return new WaitForSeconds(1.0f);
		GameObject pTemp = Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation) as GameObject;
		Physics2D.IgnoreCollision(collider ,pTemp.GetComponent<Collider2D>());
		temp = pTemp.GetComponent<Rigidbody2D>();
		temp.velocity = new Vector2 (-1.4f, 0f);

		yield return new WaitForSeconds(0.2f);
		GameObject pTemp2 = Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation) as GameObject;
		Physics2D.IgnoreCollision(collider ,pTemp2.GetComponent<Collider2D>());
		temp = pTemp2.GetComponent<Rigidbody2D>();
		temp.velocity = new Vector2 (-1.4f, 0f);

		yield return new WaitForSeconds (1.0f);
		jump.velocity = new Vector2 (-0.2f, 2.0f);
		yield return new WaitForSeconds (0.2f);
		jump.velocity = new Vector2 (0, 0);
		shot = false;
	}
}
