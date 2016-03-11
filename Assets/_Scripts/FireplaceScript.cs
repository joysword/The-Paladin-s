using UnityEngine;
using System.Collections;

public class FireplaceScript : MonoBehaviour
{
    GameObject light;
	// Use this for initialization
	void Start ()
    {
        light = transform.FindChild("firelight").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        light.GetComponent<Light>().intensity = Mathf.Sin(Time.realtimeSinceStartup * 10) / 10 + 1;
    }
}
