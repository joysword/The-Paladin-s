using UnityEngine;
using System.Collections;

public class GateScript : PromptableTriggerBase {

    public GameObject textFuture;

	GameObject gatePast;
	GameObject gateFuture;
	GameObject key;
	bool opening = false;

	public AudioSource sound;

    // Use this for initialization
    void Start () {
		key = GameObject.Find("key2");
		gatePast = GameObject.Find("TombGatePast");
		gateFuture = GameObject.Find("TombGateFuture");
		sound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!opening)
			return;

		gatePast.transform.Translate(0, 0, 1 * Time.deltaTime);
		gateFuture.transform.Translate(0, 0, 1* Time.deltaTime);
		sound.mute = false;

	}

	void Stop()
	{
		opening = false;
		sound.mute = true;
	}

	override public void OnTriggerEnter(Collider other)
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

    override public IEnumerator ShowText() {
        text.GetComponent<TextMesh>().text = "This gate needs a key to open!";
        textFuture.GetComponent<TextMesh>().text = "This gate needs a key to open!";
        text.SetActive(true);
        textFuture.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
        textFuture.SetActive(false);
    }
}
