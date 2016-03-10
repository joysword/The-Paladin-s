using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var map = GameObject.Find("map");
        
        // add mesh colliders
        foreach(Transform c in map.transform)
        {
            c.gameObject.AddComponent<MeshCollider>();
        }	
	}
}
