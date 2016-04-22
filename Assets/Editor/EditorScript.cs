using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ObjectSetter : EditorWindow
{
    [MenuItem("Stuff/Add Textures to map")] //Add a menu item to the toolbar
    static void AddTextures()
    {
        Dictionary<string, string> maps = new Dictionary<string, string>();
        Dictionary<string, Material> mats = new Dictionary<string, Material>();
        
        maps.Add("map_rock_past", "stone1");
        /*maps.Add("map_path_past", "aaaaaaa");
        maps.Add("map_grass_future", "aaaaaaa");
        maps.Add("map_rock_future", "aaaaaaa");
        maps.Add("map_waterbed_future", "aaaaaaa");
        maps.Add("map_track_future", "aaaaaaa");
        maps.Add("map_catacombs_future", "aaaaaaa");
        maps.Add("map_tomb_future", "aaaaaaa");
        maps.Add("map_water_future", "aaaaaaa");
        maps.Add("map_support_future", "aaaaaaa");
        maps.Add("map_grass_past", "aaaaaaa");
        maps.Add("map_support_past", "aaaaaaa");
        maps.Add("map_waterbed_past", "aaaaaaa");
        maps.Add("map_water_past", "aaaaaaa");
        maps.Add("map_tomb_past", "aaaaaaa");
        maps.Add("map_catacombs_past", "aaaaaaa");*/

        //foreach (var m in GameObject.Find("UnityIsShit").GetComponent<MeshRenderer>().materials)
        //    mats.Add(m.name, m);

        //foreach (var key in mats.Keys)
        //    Debug.Log(key);

        //var r = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Models/Materials");
        //foreach (var i in r)
        //    Debug.Log(i.name);

        //foreach (var name in maps.Keys)
        //{
        //    var obj = GameObject.Find(name);
        //    obj.GetComponent<MeshRenderer>().material = mats[maps[name]];
        //}

        var r = AssetDatabase.LoadAllAssetsAtPath("Assets/Models/Materials");
        Debug.Log(r.Length);
    }

    [MenuItem("Stuff/Add colliders to map")] //Add a menu item to the toolbar
    static void AddColliders()
    {
        List<GameObject> obj = new List<GameObject>();
        obj.Add(GameObject.Find("map_future"));
        obj.Add(GameObject.Find("map_future_tomb"));
        obj.Add(GameObject.Find("map_past"));
        obj.Add(GameObject.Find("map_past_tomb"));

        foreach (var o in obj)
            AddColliders(o.transform);
    }

    static void AddColliders(Transform o)
    {
        foreach (Transform c in o.transform)
        {
            AddColliders(c);

            if (c.GetComponents<MeshCollider>().Length == 0 && c.GetComponent<MeshRenderer>() != null)
                c.gameObject.AddComponent<MeshCollider>();
        }
    }
}