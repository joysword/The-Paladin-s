using UnityEngine;
using System.Collections;

abstract public class PickableBase : HighlightableBase, IPromptable {

    public bool picked = false;
    protected GameObject text;

    // Update is called once per frame
    void Update() {
        UpdateHighlight();
        if (Actionable && (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset"))) {
            Pick();
        }
    }

    abstract public void Pick();

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PickTrigger")) {
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<BoxCollider>().enabled = false;
            TurnOffHalo();
            picked = true;
			PlaySound();
            StartCoroutine("ShowText");

        }
    }

    abstract public IEnumerator ShowText();

	abstract public void PlaySound();

}
