using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (getReal3D.Input.GetButtonDown("ChangeWand")) {
			ReloadScene();
		}
	}

	public void ReloadScene() {
		Application.LoadLevel(Application.loadedLevel);
	}

    IEnumerator Respawn() {
        yield return new WaitForSeconds(3);
        ReloadScene();
    }
    public void Restart() {
        StartCoroutine("Respawn");
    }
}
