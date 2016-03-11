using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public GameManager game;
	public GameObject finishText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			finishText.SetActive(true);
			StartCoroutine("Respawn");
		}
	}

	IEnumerator Respawn() {
		yield return new WaitForSeconds(3);
		game.ReloadScene();
	}
}
