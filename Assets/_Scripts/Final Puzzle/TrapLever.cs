using UnityEngine;
using System.Collections;

public class TrapLever : MonoBehaviour {

	public bool isActive;
	public bool trapDown = false;
	public Material Glow;
	public Material Normal;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("e")){
			if (isActive) {
				Debug.Log ("LEVER ACTIVE");
				var trap = GameObject.FindGameObjectWithTag("TrapDoor1");
				if(!trapDown){
					trap.transform.Rotate(0,0,90);
					trapDown = true;
				}
				else{
					trap.transform.Rotate(0,0,-90);
					trapDown = false;
				}
			}

		}

	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo,true,null);
			var materials = GetComponentsInChildren<Renderer>();
			//var materials = GetComponentsInChildren<Renderer>().materials;
			Debug.Log ("Materail count: " + materials.Length);
			foreach ( var x in materials){
				Debug.Log ("Materail name: " + x);
				x.material.SetColor("_Color",Color.red);
			}

			isActive = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Component halo = GetComponent("Halo"); 
			halo.GetType().GetProperty("enabled").SetValue(halo,false,null);
			var materials = GetComponentsInChildren<Renderer>();
			//var materials = GetComponentsInChildren<Renderer>().materials;
			Debug.Log ("Materail count: " + materials.Length);
			foreach ( var x in materials){
				Debug.Log ("Materail name: " + x);
				x.material.SetColor("_Color",Color.white);
			}

			isActive = false;
		}
	}



}
