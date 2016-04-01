using UnityEngine;

public class OpeningManager : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    void Update() {
        if (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset")) {
            Debug.Log("pressed");
            if (text1.activeInHierarchy) {
                text1.SetActive(false);
                text2.SetActive(true);
            }
            else if (text2.activeInHierarchy) {
                text2.SetActive(false);
                text3.SetActive(true);
            }
            else if (text3.activeInHierarchy) {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
    }
}
