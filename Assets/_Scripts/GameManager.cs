using UnityEngine;
using System.Collections;
using getReal3D;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (getReal3D.Input.GetButtonDown("ChangeWand")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
