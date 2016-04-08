using UnityEngine;
using System.Collections;

public class EndingTrigger : PromptableTriggerBase {

    public GameObject textFuture;

    override public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine("ShowText");
        }
    }

    override public IEnumerator ShowText() {
        text.GetComponent<TextMesh>().text = "You: Finally, I found you, my King.\nAllthea will be freed and you will rule again";
        textFuture.GetComponent<TextMesh>().text = "You: Finally, I found you, my King.\nAllthea will be freed and you will rule again";
        text.SetActive(true);
        textFuture.SetActive(true);
        yield return new WaitForSeconds(4);
        text.GetComponent<TextMesh>().text = "King: thanks, my son! Because of you,\nour kingdom will be free of darkness and prosperous once again";
        textFuture.GetComponent<TextMesh>().text = "King: thanks, my son! Because of you,\nour kingdom will be free of darkness and prosperous once again";
        yield return new WaitForSeconds(4);
    }
}