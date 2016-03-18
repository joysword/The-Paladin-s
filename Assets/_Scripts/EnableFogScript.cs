using UnityEngine;
using System.Collections;

public class EnableFogScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		RenderSettings.fog = true;
	}
}
