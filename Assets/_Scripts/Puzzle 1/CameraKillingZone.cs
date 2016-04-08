using UnityEngine;
using System.Collections;

public class CameraKillingZone : KillingZoneBase {

    override public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            finishTextPast.GetComponent<TextMesh>().text = "The other player is detected by the spotlight. Try Again!";
            finishTextFuture.GetComponent<TextMesh>().text = "You are detected by the spotlight. Try Again!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
