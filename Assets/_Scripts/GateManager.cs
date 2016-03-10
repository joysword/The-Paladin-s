using UnityEngine;
using System.Collections;

public class GateManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Open() {
        this.gameObject.transform.Translate(0, 0, 12);
        StartCoroutine("Close");
    }

    IEnumerator Close() {
        for (float f = 12f; f >= 0; f-= 0.2f) {
            this.gameObject.transform.Translate(0, 0, -0.2f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
