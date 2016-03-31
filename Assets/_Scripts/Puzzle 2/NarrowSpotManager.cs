using UnityEngine;
using System.Collections;

public class NarrowSpotManager : MonoBehaviour, IPromptable {

    public GameObject promptTextPast;
    //GameObject board1;
    GameObject board2;
    GameObject board3;

    const string defaultText = "Seems that we can put a wooden board here";

    void Start() {
        //board1 = GameObject.Find("Board1");
        board2 = GameObject.Find("Board2");
        board3 = GameObject.Find("Board3");
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (board3.GetComponent<BoardManager>().picked) {
                GetComponent<BoxCollider>().enabled = false;
                // TODO: put board here
            }
            else if (board2.GetComponent<BoardManager>().picked) {
                promptTextPast.GetComponent<TextMesh>().text = "The wooden board(s) you have are too short";
                StartCoroutine("ShowText");
            }
            else {
                promptTextPast.GetComponent<TextMesh>().text = defaultText;
                StartCoroutine("ShowText");
            }
        }
    }

    public IEnumerator ShowText() {
        promptTextPast.SetActive(true);
        yield return new WaitForSeconds(3);
        promptTextPast.SetActive(false);
    }
}
