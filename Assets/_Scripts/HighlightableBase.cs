using UnityEngine;
using System.Collections;

public abstract class HighlightableBase : MonoBehaviour {

    protected bool isHighlighted;

    public float highlightDistance = 10f;
    public GameObject player;

    protected void UpdateHighlight() {

        if (!isHighlighted) {
            if (Vector3.Distance(player.transform.position, this.transform.position) < highlightDistance) {
                TurnOnHalo();
                isHighlighted = true;
            }
        }
        else {
            if (Vector3.Distance(player.transform.position, this.transform.position) > highlightDistance) {
                TurnOffHalo();
                isHighlighted = false;
            }
        }
    }

    protected void TurnOnHalo() {
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        var materials = GetComponentsInChildren<Renderer>();
        //var materials = GetComponentsInChildren<Renderer>().materials;
        Debug.Log("Materail count: " + materials.Length);
        foreach (var x in materials) {
            Debug.Log("Materail name: " + x);
            x.material.SetColor("_Color", Color.red);
        }
    }

    protected void TurnOffHalo() {
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        var materials = GetComponentsInChildren<Renderer>();
        //var materials = GetComponentsInChildren<Renderer>().materials;
        Debug.Log("Materail count: " + materials.Length);
        foreach (var x in materials) {
            Debug.Log("Materail name: " + x);
            x.material.SetColor("_Color", Color.white);
        }
    }
}
