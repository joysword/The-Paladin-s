using UnityEngine;
using System.Collections;

public class TrapLever : MonoBehaviour {

	public bool isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		//if (col.gameObject.tag == "Player") {
			Debug.Log ("LEVER ACTIVE");
		//}
	}
}
