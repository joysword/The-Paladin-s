using UnityEngine;
using System.Collections;

public class LeverManager : InteractableBase {

    public GameObject gatePast;
	public GameObject gateFuture;
    public GameObject logGate;
    public bool isPulled;
    
	// Use this for initialization
	void Start () {
	
	}

    override protected void Interact() {
        if (isPulled == false) {
            //var handle = GameObject.Find("wooden_lever");
            transform.Rotate(0, -180, 0);
            //handle.transform.Translate(-1,0,0);
            //handle.transform.position = new Vector3(-1.0f,0.0f,0.0f);
            isPulled = true;
            OpenGate();
        }
    }

    public void OpenGate() {
		AudioSource a = gameObject.GetComponent<AudioSource>();
		//a.mute = false;
		//a.Play();
		gatePast.transform.Translate(0, 0, 14);
		gateFuture.transform.Translate(0, 0, 14);
		StartCoroutine("Close");
        logGate.GetComponent<LoggateScript>().Open();
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
			//var handle = GameObject.Find("wooden_lever");
			transform.Rotate(0, 180, 0);
			AudioSource a = gameObject.GetComponent<AudioSource>();
			//a.mute = false;
			//a.Play();
		}
		isPulled = false;
	}
}
