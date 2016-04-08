using UnityEngine;
using System.Collections;
using System;

public class BoardManager : PickableBase {

    override public IEnumerator ShowText() {
        text.GetComponent<TextMesh>().text = "wooden board acquired!";
        text.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }

	override public void PlaySound(){
		//nothing todo for now
	}
}
