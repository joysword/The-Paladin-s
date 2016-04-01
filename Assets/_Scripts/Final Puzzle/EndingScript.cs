using UnityEngine;

public class EndingTrigger : MonoBehaviour, IPromptable {

    public GameObject endingTextPast;
    public GameObject endingTextFuture;

    public OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine("ShowText");
        }
    }

    public IEnumerator ShowText() {
        endingTextPast.GetComponent<TextMesh>().text = "You: Finally, I found you, my King. Allthea will be freed and you will rule again";
        endingTextFuture.GetComponent<TextMesh>().text = "You: Finally, I found you, my King. Allthea will be freed and you will rule again";
        endingTextPast.SetActive(true);
        endingTextFuture.SetActive(true);
        yield return new WaitForSeconds(4);
        endingTextPast.GetComponent<TextMesh>().text = "King: thanks, my son! Because of you, our kingdom will be free of darkness and prosperous once again";
        endingTextFuture.GetComponent<TextMesh>().text = "King: thanks, my son! Because of you, our kingdom will be free of darkness and prosperous once again";
        yield return new WaitForSeconds(4);
    }
}