using UnityEngine;
using System.Collections;

public abstract class PickableBase: HighlightableBase, IPromptable {

    public bool picked = false;

    public void OnTriggerEnter(Collider other) {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        picked = true;
        StartCoroutine("ShowText");
    }

    abstract public IEnumerator ShowText();
}
