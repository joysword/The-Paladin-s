using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

    // Use this for initialization
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("waterfx");
    }
    void Update()
    {
        rend.material.SetFloat("_Time", Time.realtimeSinceStartup);
    }
}
