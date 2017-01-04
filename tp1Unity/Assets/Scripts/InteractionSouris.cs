using UnityEngine;
using System.Collections;

public class InteractionSouris : MonoBehaviour {
	GameObject go, tmpObj;
    Plane plane;
    float dist;
	Vector3 v3OffSet, ObjAncPos;

	// Use this for initialization
	void Start () {
		go = new GameObject();
		go.AddComponent<GUIText>();
		go.GetComponent<GUIText>().color = Color.green;
		go.GetComponent<GUIText>().fontSize = 24;
		go.GetComponent<GUIText>().fontStyle = FontStyle.Normal;
		go.transform.position = new Vector3(0.6f,0.9f);
	}

    // Update is called once per frame
    void Update () {
		go.GetComponent<GUIText>().enabled = false;
		if (Input.GetMouseButtonUp (1)) {
			tmpObj = null;
		}
		if (Input.GetMouseButton (1)) {
            if (tmpObj != null){
				moveObject();
			} else {
                initialiseVar();
			}
		}
	}

	void moveObject () {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        plane.Raycast(ray, out dist);
        Vector3 tmp = ray.GetPoint(dist);
        tmpObj.transform.position = tmp + v3OffSet;

        //Affichage de l'objet et de sa position
        string text = tmpObj.name + ", " + tmpObj.transform.position;
        Debug.Log(text);
        go.GetComponent<GUIText>().color =  new Color(Random.value, Random.value, Random.value);
		go.GetComponent<GUIText>().enabled = true;
		go.GetComponent<GUIText>().text = text;
	}

    void initialiseVar()
    {
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject)
        {
            tmpObj = hit.collider.gameObject;
            ObjAncPos = tmpObj.transform.position;
            plane.SetNormalAndPosition(Camera.main.transform.forward, ObjAncPos);
            plane.Raycast(ray, out dist);
            v3OffSet = ObjAncPos - ray.GetPoint(dist);
        }
    }
}
