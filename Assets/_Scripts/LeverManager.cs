using UnityEngine;
using System.Collections;

public class LeverManager : MonoBehaviour {

    public GateManager gate;
    public bool isPulled;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("e")) {
            this.gameObject.transform.Rotate(-60, 0, 0);
            isPulled = true;
            gate.Open();
        }
	}
}
