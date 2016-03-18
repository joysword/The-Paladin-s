using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	GameObject gatePast;
	GameObject gateFuture;
	GameObject key;
	bool opening = false;
	// Use this for initialization
	void Start () {
		key = GameObject.Find("key");
		gatePast = GameObject.Find("TombGatePast");
		gateFuture = GameObject.Find("TombGateFuture");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!opening)
			return;

		gatePast.transform.Translate(0,1 * Time.deltaTime,0);
		gateFuture.transform.Translate(0,1* Time.deltaTime,0);

	}

	void Stop()
	{
		opening = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(key.GetComponent<KeyScript>().picked)
		{
			GetComponent<BoxCollider>().enabled = false;
			opening = true;
			Invoke("Stop",5);
		}
	}
}
