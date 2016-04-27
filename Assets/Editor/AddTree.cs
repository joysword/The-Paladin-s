//C# Example
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AddTreeHook))]
public class AddTree : Editor
{
    GameObject controller;

    public void OnSceneGUI()
    {
        controller = GameObject.Find("TreeAddController");

        if (!controller.GetComponent<AddTreeHook>().Enable)
            return;

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && !Event.current.alt)
        {
            Debug.Log("Tree copied");
            Event.current.Use();

            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                var obj = GameObject.Instantiate(controller.GetComponent<AddTreeHook>().ObjectToClone);
                var objt = obj.transform;
                objt.position = hit.point + new Vector3(0, -0.5f, 0);
                var rot = objt.eulerAngles;
                rot.y = Random.value * 360;
                objt.eulerAngles = rot;
                objt.localScale = new Vector3(Random.value * 40 + 80, Random.value * 40 + 80, Random.value * 40 + 80);
                obj.transform.parent = GameObject.Find("Flora").transform;
            }
        }
    }
}
