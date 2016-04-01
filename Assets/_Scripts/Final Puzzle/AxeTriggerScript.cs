using UnityEngine;
using System.Collections;

public class AxeTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) {
            GameObject.Find("AxePivot").GetComponent<AxeSwing>().Activate();
            Destroy(this);
        }
	}
}
