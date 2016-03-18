using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
	public bool Picked = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		GetComponent<Renderer>().enabled = false;
		GetComponent<BoxCollider>().enabled = false;
		Picked = true;
	}
}
