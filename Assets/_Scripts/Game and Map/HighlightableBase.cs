using UnityEngine;
using System.Collections;

public class HighlightableBase : MonoBehaviour {

    public Material Glow;
    public Material Normal;

    protected bool isHighlighted;

    bool isInteractable = false;
    public float highlightDistance = 10f;
    public GameObject player;

    protected void UpdateHighlight() {

        if (!isHighlighted) {
            if (Vector3.Distance(player.transform.position, transform.position) < highlightDistance) {
                TurnOnHalo();
                isHighlighted = true;
            }
        }
        else {
            if (Vector3.Distance(player.transform.position, transform.position) > highlightDistance) {
                TurnOffHalo();
                isHighlighted = false;
            }
        }
    }

    public bool Actionable {
        get {
            return isInteractable;
        }
        set { isInteractable = value; }
    }


    private void TurnOnHalo() {
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        //var materials = GetComponentsInChildren<Renderer>();
        //var materials = GetComponentsInChildren<Renderer>().materials;
        //Debug.Log("Materail count: " + materials.Length);
        //foreach (var x in materials) {
        //    Debug.Log("Material name: " + x);
        //    x.material.SetColor("_Color", Color.red);
        //}
    }

    protected void TurnOffHalo() {
        Component halo = GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
        //var materials = GetComponentsInChildren<Renderer>();
        //var materials = GetComponentsInChildren<Renderer>().materials;
        //Debug.Log("Materail count: " + materials.Length);
        //foreach (var x in materials) {
        //    Debug.Log("Material name: " + x);
        //   x.material.SetColor("_Color", Color.white);
        //}
    }
}
