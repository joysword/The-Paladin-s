using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {        
        // add mesh colliders
        foreach(Transform c in transform)
        {
            c.gameObject.AddComponent<MeshCollider>();
        }	
	}
}
