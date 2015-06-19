using UnityEngine;
using System.Collections;

public class FireGuyShot : MonoBehaviour {

	public GameObject projectile;
	public Transform projectileSpawnPoint;
	public BoxCollider2D collider;
	Rigidbody2D temp;
	bool shot = false;
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

		yield return new WaitForSeconds(1.5f);
		GameObject pTemp = Instantiate(projectile,projectileSpawnPoint.position,projectileSpawnPoint.rotation) as GameObject;
		Physics2D.IgnoreCollision(collider ,pTemp.GetComponent<Collider2D>());
		temp = pTemp.GetComponent<Rigidbody2D>();
		temp.velocity = new Vector2 (-1.4f, 2f);
		yield return new WaitForSeconds(0.2f);
		shot = false;
	}
}

