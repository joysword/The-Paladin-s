using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {
    int dir;
	// Use this for initialization
	void Start () {
	dir = -1;
	}
	
	// Update is called once per frame
	void Update () {
	transform.Rotate(0,0,dir*30 * Time.deltaTime);

        if(transform.eulerAngles.y < 26 && dir == -1)
            dir = 1;
        else if(transform.eulerAngles.y > 156 && dir == 1)
            dir = -1;
	}
}
