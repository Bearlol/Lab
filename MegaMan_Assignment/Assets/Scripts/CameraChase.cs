using UnityEngine;
using System.Collections;

public class CameraChase : MonoBehaviour {
	public GameObject target;

	
	// Use this for initialization
	void Start () {
		if (!target) {
			Debug.Log("Target not linked in Inspector");
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (target) {

				transform.position = new Vector3(target.transform.position.x,
				                                 target.transform.position.y,
				                                 transform.position.z);
		}
	}
	
	
}