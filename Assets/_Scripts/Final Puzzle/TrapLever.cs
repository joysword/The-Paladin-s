using UnityEngine;
using System.Collections;

public class TrapLever : InteractableBase {

	public bool trapDown = false;

    override protected void Interact() {
		AudioSource a = gameObject.GetComponent<AudioSource> ();
		//a.mute = false;
		//a.Play ();
        Debug.Log("hereerere");
        GameObject trap = GameObject.FindWithTag("TrapDoor1");
        Debug.Log(trap);
        if (!trapDown) {
            trap.transform.Rotate(0, 0, 90);
            transform.Rotate(0, -180, 0);
            trapDown = true;
        }
        else {
            trap.transform.Rotate(0, 0, -90);
            transform.Rotate(0, 180, 0);
            trapDown = false;
        }
    }
}
