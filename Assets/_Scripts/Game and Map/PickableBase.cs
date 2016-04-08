using UnityEngine;
using System.Collections;

abstract public class PickableBase : HighlightableBase, IPromptable {

    [HideInInspector]
    public int keyCount = 0;
    public bool picked = false;
    public GameObject text;

    const string _str = "Press O (circle) to pick";

    // Update is called once per frame
    void Update() {
        if (Actionable) {
            UpdateHighlight();
            if (Actionable && (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset"))) {
                Pick();
            }
        }
    }

    public virtual void Pick() {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        TurnOffHalo();
        picked = true;
        Actionable = false;
        PlaySound();
        StartCoroutine("ShowText");
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("ActionTrigger") && !picked) {
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

    abstract public IEnumerator ShowText();

	abstract public void PlaySound();

}
