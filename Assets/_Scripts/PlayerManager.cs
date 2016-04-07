using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    GameObject objectInHand;

	// Use this for initialization
	void Start () {
        objectInHand = null;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pickable")) {
            
        }
    }
}
