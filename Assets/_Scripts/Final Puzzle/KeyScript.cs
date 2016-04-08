using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class KeyScript : PickableBase {
	public AudioClip ping;
	AudioSource audioSource;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

	override public void PlaySound() {
        audioSource.PlayOneShot (ping, 0.7f);
		//Debug.Log ("Key Sound Played!");
	}

    override public IEnumerator ShowText() {
        text.GetComponent<TextMesh>().text = "key acquired!";
        text.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }

    public override void Pick()
    {
        base.Pick();
        keyCount++;
    }
}
