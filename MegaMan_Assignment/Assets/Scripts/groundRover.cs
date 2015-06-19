using UnityEngine;
using System.Collections;

public class groundRover : MonoBehaviour {


	Rigidbody2D rigidb;
	bool left = false;
	// Use this for initialization


	void Start () {
		rigidb = GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame
	void Update () {
		if (left == false)
			rigidb.velocity = new Vector2 (1.0f, 0);
		else
			rigidb.velocity = new Vector2 (-1.0f, 0);


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

}

