using UnityEngine;
using System.Collections;

public class TrapLever : MonoBehaviour {

	public bool isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			Debug.Log ("LEVER ACTIVE");
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") {

			isActive = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			
			isActive = false;
		}
	}

}
