using UnityEngine;
using System.Collections;

public class deathChasm : KillingZoneBase
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("other:", other);
        if (other.CompareTag("Player"))
        {
            Debug.Log("adfasdfasdf die die die");
            finishTextPast.GetComponent<TextMesh>().text = "You are dead! Try not to fall!";
            finishTextFuture.GetComponent<TextMesh>().text = "You are dead! Try not to fall!";
            finishTextPast.SetActive(true);
            finishTextFuture.SetActive(true);
            GameManager game = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            game.Restart();
            Debug.Log("hereer");
        }
    }
}
