﻿using UnityEngine;
using System.Collections;

public class KeyScript : PickableBase {

    public GameObject pickTextPast;
    // public GameObject finishTextFuture;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        UpdateHighlight();
    }

    override public IEnumerator ShowText() {
        pickTextPast.GetComponent<TextMesh>().text = "key acquired!";
        pickTextPast.SetActive(true);
        yield return new WaitForSeconds(3);
        pickTextPast.SetActive(false);
    }
}
