using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeavesPastBBScript : MonoBehaviour
{
    public string TargetCam = "RealCameraPast";

    List<Transform> allLeaves;

    GameObject cam;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindGameObjectWithTag(TargetCam);
        allLeaves = new List<Transform>();

        FindLeavesRec(transform);
    }

    void FindLeavesRec(Transform parent)
    {
        foreach (Transform c in parent)
        {
            FindLeavesRec(c);

            if (c.tag == "Leaves" || c.name.IndexOf("Leaves") == 0)
                allLeaves.Add(c);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Transform c in allLeaves)
        {
            c.LookAt(c.transform.position + cam.transform.rotation * Vector3.back,
                cam.transform.rotation * Vector3.up);
        }
    }
}
