using UnityEngine;
using System.Collections;
using System;

public class BoardManager : PickableBase {

    public GameObject pickText;

    override public IEnumerator ShowText() {
        pickText.GetComponent<TextMesh>().text = "wooden board acquired!";
        pickText.SetActive(true);
        yield return new WaitForSeconds(3);
        pickText.SetActive(false);
    }

	override public void PlaySound(){
		//nothing todo for now
	}

    public override void Pick() {
        PlaySound();
    }
}
