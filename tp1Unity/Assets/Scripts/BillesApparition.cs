using UnityEngine;
using System.Collections;

public class BillesApparition : MonoBehaviour {
    public GameObject prefabWood, prefabIce;
    bool iceOrWood;
	// Use this for initialization
	void Start () {
        iceOrWood = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseInScreen = Input.mousePosition;
            mouseInScreen.z = 15.5f;
            Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mouseInScreen);
            GameObject sphere;
            if (iceOrWood)
                sphere = Instantiate(prefabWood);
            else
                sphere = Instantiate(prefabIce);
            sphere.transform.position = mouseInWorld;
            iceOrWood = !iceOrWood;
        }
    }
}
