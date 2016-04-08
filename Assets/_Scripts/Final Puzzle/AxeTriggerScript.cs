using UnityEngine;
using System.Collections;

public class AxeTriggerScript : MonoBehaviour {
    public GameObject axePivot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) {

            axePivot.GetComponent<AxeSwing>().Activate();
            Destroy(this);
        }
	}
}
