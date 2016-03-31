using UnityEngine;
using System.Collections;

interface IPromptable {

    void OnTriggerEnter(Collider other);

    IEnumerator ShowText();
}