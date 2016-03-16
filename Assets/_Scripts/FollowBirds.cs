using UnityEngine;
using System.Collections;

public class FollowBirds : MonoBehaviour {
    Transform target;
	// Use this for initialization
	void Start ()
    {
        target = GameObject.Find("leader").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
