using UnityEngine;

abstract public class InteractableBase : HighlightableBase {

    const string _str = "Press O (circle) to interact";
    public GameObject text;

    void Update() {
        UpdateHighlight();
        if (Actionable && (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset"))) {
            Interact();
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ActionTrigger")) {
            Actionable = true;
            text.GetComponent<TextMesh>().text = _str;
            text.SetActive(true);
        }
    }
    abstract protected void Interact();
}
