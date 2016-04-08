using UnityEngine;
using System.Collections;

public class BoardManager : PickableBase {

    public GameObject pickText;

    // Use this for initialization
    void Start() {

    }
	
	// Update is called once per frame
	void Update () {
        if (!picked) {
            UpdateHighlight();
        }
    }

    override public IEnumerator ShowText() {
        pickText.GetComponent<TextMesh>().text = "wooden board acquired!";
        pickText.SetActive(true);
        yield return new WaitForSeconds(3);
        pickText.SetActive(false);
    }

	override public void PlaySound(){
		//nothing todo for now
	}
}
