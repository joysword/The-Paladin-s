using UnityEngine;
using System.Collections;
using getReal3D;

public class LeverManager : MonoBehaviour {

    public GateManager gate;
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
            	gate.Open();
			}
        }
	}

	public void Reset() {
		//this.gameObject.transform.Rotate (60,0,0);
		var handle = GameObject.Find("wooden_lever");
		handle.transform.Rotate(0,180,0);
		//handle.transform.Translate(1,0,0);

		isPulled = false;
	}
}
