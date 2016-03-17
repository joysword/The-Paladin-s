using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour {
    Transform target;
    public string targetName = "leader";
	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find(targetName).transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
