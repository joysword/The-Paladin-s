using UnityEngine;

abstract public class InteractableBase : HighlightableBase {

    void Update() {
        UpdateHighlight();
        if (Actionable && (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset"))) {
            Interact();
        }
    }

    abstract protected void Interact();
}
