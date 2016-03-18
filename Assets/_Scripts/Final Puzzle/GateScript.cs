using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour {

	GameObject gatePast;
	GameObject gateFuture;
	GameObject key;
	bool opening = false;

    public GameObject finishTextPast;

    // Use this for initialization
    void Start () {
		key = GameObject.Find("key");
		gatePast = GameObject.Find("TombGatePast");
		gateFuture = GameObject.Find("TombGateFuture");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!opening)
			return;

		gatePast.transform.Translate(0,1 * Time.deltaTime,0);
		gateFuture.transform.Translate(0,1* Time.deltaTime,0);

	}

	void Stop()
	{
		opening = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(key.GetComponent<KeyScript>().picked)
		{
			GetComponent<BoxCollider>().enabled = false;
			opening = true;
			Invoke("Stop",5);
		}
        else {
            StartCoroutine("ShowText");
        }
	}

    IEnumerator ShowText() {
        finishTextPast.GetComponent<TextMesh>().text = "This gate needs a key to open!";
        //finishTextFuture.GetComponent<TextMesh>().text = "key acquired!";
        finishTextPast.SetActive(true);
        //finishTextFuture.SetActive(true);
        yield return new WaitForSeconds(3);
        finishTextPast.SetActive(false);
        //finishTextFuture.SetActive(false);
    }
}
