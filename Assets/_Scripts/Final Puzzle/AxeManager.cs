using UnityEngine;
using System.Collections;

public class AxeManager : MonoBehaviour {

    public GameObject finishTextPast;
    public GameObject finishTextFuture;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // GameObject finishTextPast = GameObject.FindGameObjectWithTag("FinishTextPast");
            // GameObject finishTextFuture = GameObject.FindGameObjectWithTag("FinishTextFuture");
            finishTextPast.GetComponent<TextMesh>().text = "You are killed by the axe. Try Again!";            
            finishTextFuture.GetComponent<TextMesh>().text = "The other player is killed by the axe. Try Again!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
