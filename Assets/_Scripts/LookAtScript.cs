using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour {
    Transform target = null;
    public string targetName = "";
	// Use this for initialization
	void Start ()
    {
        if(targetName != "")
            target = GameObject.Find(targetName).transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
            transform.LookAt(target);
	}
}
