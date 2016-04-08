﻿using UnityEngine;
using System.Collections;

public class NarrowSpotManager : PromptableTriggerBase {

    //GameObject board1;
    GameObject board2;
    GameObject board3;
    public GameObject boardOnCanyon;

    const string defaultText = "Seems that we can put a wooden board here";

    void Start() {
        //board1 = GameObject.Find("Board1");
        board2 = GameObject.Find("Board2");
        board3 = GameObject.Find("Board3");
    }

    override public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (board3.GetComponent<BoardManager>().picked) {
                text.GetComponent<TextMesh>().text = "wooden board is put over the canyon";
                boardOnCanyon.SetActive(true);
                GetComponent<BoxCollider>().enabled = false;
                StartCoroutine("ShowText");
            }
            else if (board2.GetComponent<BoardManager>().picked) {
                text.GetComponent<TextMesh>().text = "The wooden board(s) you have are too short";
                StartCoroutine("ShowText");
            }
            else {
                text.GetComponent<TextMesh>().text = defaultText;
                StartCoroutine("ShowText");
            }
        }
    }

}
