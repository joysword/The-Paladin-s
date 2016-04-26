//C# Example
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameObject))]
public class AddTree : Editor
{
    public bool Enable = true;

    public void OnSceneGUI()
    {
        if (!Enable)
            return;

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0 && !Event.current.alt)
        {
            Debug.Log("Mouse");
            Event.current.Use();

            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                var obj = GameObject.Instantiate(GameObject.Find("ElderTree"));
                var objt = obj.transform;
                objt.position = hit.point + new Vector3(0, -0.5f, 0);
                var rot = objt.eulerAngles;
                rot.y = Random.value * 360;
                objt.eulerAngles = rot;
            }
        }
    }
}