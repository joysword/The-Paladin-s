using UnityEngine;
using System.Collections;

public class BoardManager : PickableBase {

    public GameObject pickTextPast;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {
        UpdateHighlight();
    }

    override public IEnumerator ShowText() {
        pickTextPast.GetComponent<TextMesh>().text = "wooden board acquired!";
        pickTextPast.SetActive(true);
        yield return new WaitForSeconds(3);
        pickTextPast.SetActive(false);
    }
}
