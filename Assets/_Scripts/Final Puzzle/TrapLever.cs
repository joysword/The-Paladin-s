using UnityEngine;
using System.Collections;

public class TrapLever : InteractableBase {

	public bool trapDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHighlight();
        Interact();
	}

    override protected void Interact() {
        if (Input.GetKeyDown("f")) {
            if (isHighlighted) {
                Debug.Log("LEVER ACTIVE");
                var trap = GameObject.FindGameObjectWithTag("TrapDoor1");
                if (!trapDown) {
                    trap.transform.Rotate(0, 0, 90);
                    trapDown = true;
                }
                else {
                    trap.transform.Rotate(0, 0, -90);
                    trapDown = false;
                }
            }

        }
    }

    /*
	public void TurnOnHalo()
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
	public void TurnOffHalo()
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
	} */
}
