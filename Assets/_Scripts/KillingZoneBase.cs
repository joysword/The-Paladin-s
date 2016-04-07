using UnityEngine;
using System.Collections;

public class KillingZoneBase : MonoBehaviour {

    protected static GameObject finishTextPast;
    protected static GameObject finishTextFuture;

    void Start() {
        finishTextPast = GameObject.FindWithTag("PlayerTextPast");
        finishTextFuture = GameObject.FindWithTag("PlayerTextFuture");
    }

    virtual public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            finishTextPast.GetComponent<TextMesh>().text = "You are dead!";
            finishTextFuture.GetComponent<TextMesh>().text = "You are dead!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
