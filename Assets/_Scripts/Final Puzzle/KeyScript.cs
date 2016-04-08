using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class KeyScript : PickableBase {
	public AudioClip ping;
	AudioSource audio;

    // Use this for initialization
    void Start() {
		audio = GetComponent<AudioSource>();
    }

	override public void PlaySound() {
		audio.PlayOneShot (ping, 0.7f);
		//Debug.Log ("Key Sound Played!");
	}

    override public IEnumerator ShowText() {
        text.GetComponent<TextMesh>().text = "key acquired!";
        text.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }
}
