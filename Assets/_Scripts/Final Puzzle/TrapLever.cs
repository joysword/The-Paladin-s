using UnityEngine;
using System.Collections;

public class TrapLever : MonoBehaviour {

	public bool isActive;
	public bool trapDown = false;
	public Material Glow;
	public Material Normal;

    public float activateDistance = 10f;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isActive) {
            if (Vector3.Distance(player.transform.position, this.transform.position) < activateDistance) {
                TurnOnHalo();
            }
        }
        else {
            if (Vector3.Distance(player.transform.position, this.transform.position) > activateDistance) {
                TurnOffHalo();
            }
        }

		if (Input.GetKeyDown("f")){
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
	void TurnOnHalo()
	{
		
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
	void TurnOffHalo()
	{
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
