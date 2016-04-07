using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class KeyScript : PickableBase {
	public AudioClip ping;
	AudioSource audio;

    public GameObject pickTextPast;
    // public GameObject finishTextFuture;

    // Use this for initialization
    void Start() {
		audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        UpdateHighlight();
    }

	override public void PlaySound() {
		audio.PlayOneShot (ping,0.2f);
		//Debug.Log ("Key Sound Played!");
	}

    override public IEnumerator ShowText() {
        pickTextPast.GetComponent<TextMesh>().text = "key acquired!";
        pickTextPast.SetActive(true);
        yield return new WaitForSeconds(3);
        pickTextPast.SetActive(false);
		Debug.Log ("Key Acquired!");
    }
}
