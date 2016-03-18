﻿using UnityEngine;
using System.Collections;
using getReal3D;

public class LeverManager : MonoBehaviour {

    public GameObject gatePast;
	public GameObject gateFuture;
    public bool isPulled;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (UnityEngine.Input.GetButtonDown("e") || getReal3D.Input.GetButtonDown("Reset")) {
			if (isPulled == false) {
            	//this.gameObject.transform.Rotate(-60, 0, 0);
				var handle = GameObject.Find("wooden_lever");
				handle.transform.Rotate(0,-180,0);
				//handle.transform.Translate(-1,0,0);
				//handle.transform.position = new Vector3(-1.0f,0.0f,0.0f);


            	isPulled = true;
				OpenGate();
			}
        }
	}

	public void OpenGate() {
		gatePast.transform.Translate(0, 0, 14);
		gateFuture.transform.Translate (0,0,14);
		StartCoroutine("Close");
	}

	IEnumerator Close() {
		for (float f = 14f; f >= 0; f-= 0.2f) {
			gatePast.transform.Translate(0, 0, -0.2f);
			gateFuture.transform.Translate(0, 0, -0.2f);
			yield return new WaitForSeconds(0.15f);
		}
		Reset();
	}

	public void Reset() {
		if (isPulled) {
			//this.gameObject.transform.Rotate (60,0,0);
			var handle = GameObject.Find("wooden_lever");
			handle.transform.Rotate(0,180,0);
		}

		isPulled = false;
	}
}
