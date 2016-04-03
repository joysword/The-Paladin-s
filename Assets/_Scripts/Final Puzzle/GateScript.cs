using UnityEngine;
using System.Collections;

public class GateScript : MonoBehaviour, IPromptable {

	GameObject gatePast;
	GameObject gateFuture;
	GameObject key;
	bool opening = false;

    public GameObject promptTextPast;
    public GameObject promptTextFuture;

    // Use this for initialization
    void Start () {
		key = GameObject.Find("key2");
		gatePast = GameObject.Find("TombGatePast");
		gateFuture = GameObject.Find("TombGateFuture");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!opening)
			return;

		gatePast.transform.Translate(0, 0, 1 * Time.deltaTime);
		gateFuture.transform.Translate(0, 0, 1* Time.deltaTime);

	}

	void Stop()
	{
		opening = false;
	}

	public void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player")) {
            if (key.GetComponent<KeyScript>().picked) {
                GetComponent<BoxCollider>().enabled = false;
                opening = true;
                Invoke("Stop", 5);
            }
            else {
                StartCoroutine("ShowText");
            }
        }
	}

    public IEnumerator ShowText() {
        promptTextPast.GetComponent<TextMesh>().text = "This gate needs a key to open!";
        promptTextFuture.GetComponent<TextMesh>().text = "This gate needs a key to open!";
        promptTextPast.SetActive(true);
        promptTextFuture.SetActive(true);
        yield return new WaitForSeconds(3);
        promptTextPast.SetActive(false);
        promptTextFuture.SetActive(false);
    }
}
