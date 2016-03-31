using UnityEngine;
using System.Collections;

public abstract class PickableBase: MonoBehaviour {

    public bool picked = false;

    void OnTriggerEnter(Collider other) {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        picked = true;
        StartCoroutine("ShowText");
    }

    abstract public IEnumerator ShowText();
}
