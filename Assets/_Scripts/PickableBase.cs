using UnityEngine;
using System.Collections;

public abstract class PickableBase: HighlightableBase, IPromptable {

    public bool picked = false;
    protected GameObject textPast;
    protected GameObject textFuture;

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PickTrigger")) {
            //GetComponent<Renderer>().enabled = false;
            //GetComponent<BoxCollider>().enabled = false;
            TurnOffHalo();
            picked = true;
            StartCoroutine("ShowText");
        }
    }

    public void ShowHint() {
        
    }

    abstract public IEnumerator ShowText();
}
