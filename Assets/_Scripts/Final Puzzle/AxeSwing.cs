using UnityEngine;
using System.Collections;

public class AxeSwing : MonoBehaviour {

	public bool Active = false;
	float offset;

	// Use this for initialization
	void Start ()
	{

	}

	public void Activate()
	{
		Active = true;
		offset = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if(Input.GetKey(KeyCode.A))
		//	Activate();

		if(!Active)
			return;

		var rot = transform.eulerAngles;
		rot.z = Mathf.Cos(Time.realtimeSinceStartup - offset) * -34;
		transform.eulerAngles = rot;
	}
}
