using UnityEngine;
using System.Collections.Generic;

public class TrainScript : MonoBehaviour {
    Vector3 resetPos;
    float velocity = -60;
    AudioSource horn;
	// Use this for initialization
	void Start () {
        resetPos = transform.position;
        horn = new List<AudioSource>(GetComponents<AudioSource>()).Find(t => t.clip.name == "horn");
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);

        if (transform.position.x < -400)
            transform.position = resetPos;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("horn");
        horn.Play();
    }
}
