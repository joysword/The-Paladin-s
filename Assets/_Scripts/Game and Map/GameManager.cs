using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Transform[] spawnPointsPast;
    public Transform[] spawnPointsFuture;

    public GameObject player1;
    public GameObject player2;

    int index = 0;

	// Use this for initialization
	void Start () {
        index = 0;
        setPosition();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("i") || getReal3D.Input.GetButtonDown("ChangeWand")) {
            if (index >= spawnPointsPast.Length) {
                ReloadScene();
            }
            setPosition();
		}
	}

    void setPosition() {
        player1.transform.position = spawnPointsPast[index].position;
        player1.transform.rotation = spawnPointsPast[index].rotation;
        player2.transform.position = spawnPointsFuture[index].position;
        player2.transform.rotation = spawnPointsFuture[index].rotation;
        index++;
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
