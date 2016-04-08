using UnityEngine;
using System.Collections;

public class AxeKillingZone : KillingZoneBase {

    override public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            finishTextPast.GetComponent<TextMesh>().text = "You are killed by the axe. Try Again!";            
            finishTextFuture.GetComponent<TextMesh>().text = "The other player is killed by the axe. Try Again!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
