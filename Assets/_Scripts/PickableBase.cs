using UnityEngine;
using System.Collections;

public abstract class PickableBase: HighlightableBase, IPromptable {

    public bool picked = false;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            TurnOffHalo();
            picked = true;
            StartCoroutine("ShowText");
        }
    }

    abstract public IEnumerator ShowText();
}
