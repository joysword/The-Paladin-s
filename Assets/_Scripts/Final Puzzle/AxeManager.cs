using UnityEngine;
using System.Collections;

public class AxeManager : MonoBehaviour {

    GameObject finishTextPast;
    GameObject finishTextFuture;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            finishTextPast = GameObject.FindGameObjectWithTag("PlayerTextPast");
            finishTextFuture = GameObject.FindGameObjectWithTag("PlayerTextFuture");
            finishTextPast.GetComponent<TextMesh>().text = "You are killed by the axe. Try Again!";            
            finishTextFuture.GetComponent<TextMesh>().text = "The other player is killed by the axe. Try Again!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
