using UnityEngine;
using System.Collections;

public class tombSoundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider col){
		if(col.tag == "Player"){
			GameObject tomb = GameObject.Find("map_tomb_past");
			GameObject past = GameObject.Find("Past");
			GameObject fire = GameObject.Find("fireplace");
			AudioSource sound = tomb.GetComponent<AudioSource>();
			AudioSource sound2 = past.GetComponent<AudioSource>();
			AudioSource sound3 = fire.GetComponentInChildren<AudioSource>();
			sound.mute = false;
			sound2.mute = true;
			sound3.mute = true;
			//Debug.Log("found" + tomb.name);
		}
	}
	void OnTriggerExit(Collider col){
		if(col.tag == "Player"){
			GameObject tomb = GameObject.Find("map_tomb_past");
			GameObject past = GameObject.Find("Past");
			GameObject fire = GameObject.Find("fireplace");
			AudioSource sound = tomb.GetComponent<AudioSource>();
			AudioSource sound2 = past.GetComponent<AudioSource>();
			AudioSource sound3 = fire.GetComponentInChildren<AudioSource>();
			sound.mute = true;
			sound2.mute = false;
			sound3.mute = false;
			//Debug.Log("found" + tomb.name);
		}
		//Debug.Log("found" + tomb.name);
	}
}
