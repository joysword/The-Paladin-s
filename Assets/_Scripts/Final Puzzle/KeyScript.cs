using UnityEngine;
using System.Collections;

public class KeyScript : PickableBase {
    public GameObject finishTextPast;
    // public GameObject finishTextFuture;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Debug.Log(picked);
    }

    override public IEnumerator ShowText() {
        finishTextPast.GetComponent<TextMesh>().text = "key acquired!";
        //finishTextFuture.GetComponent<TextMesh>().text = "key acquired!";
        finishTextPast.SetActive(true);
        //finishTextFuture.SetActive(true);
        yield return new WaitForSeconds(3);
        finishTextPast.SetActive(false);
        //finishTextFuture.SetActive(false);
    }

}
