using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
    public bool picked = false;
    public GameObject finishTextPast;
    // public GameObject finishTextFuture;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        GetComponent<Renderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        picked = true;
        StartCoroutine("ShowText");
    }

    IEnumerator ShowText() {
        finishTextPast.GetComponent<TextMesh>().text = "key acquired!";
        //finishTextFuture.GetComponent<TextMesh>().text = "key acquired!";
        finishTextPast.SetActive(true);
        //finishTextFuture.SetActive(true);
        yield return new WaitForSeconds(3);
        finishTextPast.SetActive(false);
        //finishTextFuture.SetActive(false);
    }

}
