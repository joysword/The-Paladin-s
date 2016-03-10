using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

    GameObject cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Camera");
        foreach (Transform c in transform)
        {
            c.localScale = c.localScale * 2;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Transform c in transform)
        {
            c.LookAt(c.transform.position + cam.transform.rotation * Vector3.back,
                cam.transform.rotation * Vector3.up);
        }
    }
}
