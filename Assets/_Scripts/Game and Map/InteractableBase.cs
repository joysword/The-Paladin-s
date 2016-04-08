using UnityEngine;

abstract public class InteractableBase : HighlightableBase {

    const string _str = "Press O (circle) to interact";
    public GameObject text;

    void Start() {
    }

    void Update() {
        if (Actionable) {
            UpdateHighlight();
            if (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset")) {
                Interact();
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ActionTrigger")) {
            Actionable = true;
            text.GetComponent<TextMesh>().text = _str;
            text.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("ActionTrigger")) {
            Actionable = false;
            text.SetActive(false);
        }
    }

    abstract protected void Interact();
}
