using UnityEngine;
using System.Collections;

public class TrainDeathTrigger : KillingZoneBase {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishTextPast.GetComponent<TextMesh>().text = "The other player is hit by the train! Follow his order!";
            finishTextFuture.GetComponent<TextMesh>().text = "You are hit by the train! Try again!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
        }
    }
}
