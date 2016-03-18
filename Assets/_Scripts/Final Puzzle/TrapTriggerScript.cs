using UnityEngine;
using System.Collections;

public class TrapTriggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){


		if(other.tag == "Guard"){
			Debug.Log ("GUARD TOUCHING THE COLLIDER");
			//var trapdoor = GameObject.Find ("trap_door_lever");
			//bool isDown = trapdoor.GetComponent<TrapLever> ().trapDown;
			//if(isDown){
			//	GameObject.Destroy(other.gameObject);
			//}
		}//*/

	}
}
