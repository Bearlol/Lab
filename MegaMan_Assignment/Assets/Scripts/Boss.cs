using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	
	Rigidbody2D rigidb;
	bool left = true;
	bool timer = false;
	public int jumpForce;
	// Use this for initialization
	void Start () {
		rigidb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(left == false)
			rigidb.velocity = new Vector2(1.3f, 0);
		else
		rigidb.velocity = new Vector2(-1.3f,0);
			
		if (timer == false) {
			timer = true;
			StartCoroutine(pause ());
			//rigidb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			timer=false;
		}

			
	}



	void OnTriggerEnter2D(Collider2D c)
	{	
		if (c.gameObject.tag == "Flipper") {
			if (left == false) {
				left = true;
			} else {
				left = false;
			}
		}
	}

	IEnumerator pause() {
		yield return new WaitForSeconds(8.0f);
	}

}
