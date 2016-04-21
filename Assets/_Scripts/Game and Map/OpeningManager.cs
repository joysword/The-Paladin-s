using UnityEngine;

public class OpeningManager : MonoBehaviour {

    public GameObject titlep;
    public GameObject subtitlep;
    public GameObject continuep;

    public GameObject text1p;
    public GameObject text2p;
    public GameObject text3p;

    public GameObject titlef;
    public GameObject subtitlef;
    //public GameObject continuef;

    public GameObject text1f;
	public GameObject text2f;
	public GameObject text3f;


    void Update() {
        if (Input.GetKeyDown("f") || getReal3D.Input.GetButtonDown("Reset")) {
            if (titlep.activeInHierarchy) {
                titlep.SetActive(false);
                subtitlep.SetActive(false);
                titlef.SetActive(false);
                subtitlef.SetActive(false);
                
                text1p.SetActive(true);
                continuep.GetComponent<TextMesh>().text = "Press O to continue..";
                text1f.SetActive(true);
                //continuef.GetComponent<TextMesh>().text = "Press O to continue..";
            }
            else if (text1p.activeInHierarchy) {
                text1p.SetActive(false);
				text1f.SetActive(false);
				text2p.SetActive(true);
				text2f.SetActive(true);
            }
            else if (text2p.activeInHierarchy) {
                text2p.SetActive(false);
				text2f.SetActive(false);

                text3p.SetActive(true);
                continuep.GetComponent<TextMesh>().text = "Press O to start";
				text3f.SetActive(true);
            }
            else if (text3p.activeInHierarchy) {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
    }
}
