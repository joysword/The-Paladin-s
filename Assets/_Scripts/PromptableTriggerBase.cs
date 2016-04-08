using UnityEngine;
using System.Collections;

abstract public class PromptableTriggerBase : MonoBehaviour, IPromptable {

    public GameObject text;

    abstract public void OnTriggerEnter(Collider other);

    virtual public IEnumerator ShowText() {
        text.SetActive(true);
        yield return new WaitForSeconds(3);
        text.SetActive(false);
    }
}
