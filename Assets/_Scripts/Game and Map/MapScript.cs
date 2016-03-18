using UnityEngine;
using System.Collections;

public class MapScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {        
        // add mesh colliders
		AddColliders(transform);	
	}

	void AddColliders(Transform t)
	{
		foreach(Transform c in t)
		{
			c.gameObject.AddComponent<MeshCollider>();
			AddColliders(c);
		}
	}
}
