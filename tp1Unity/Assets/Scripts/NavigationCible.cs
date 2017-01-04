using UnityEngine;
using System.Collections;

public class NavigationCible : MonoBehaviour {
    public bool rotationQ3 = true;
    Vector3 firstCameraPos, hitPosition;
    Vector3 firstMousePos;
    bool objectSelected;

    //Attention, pour la souris, le y bas = 0 et le y haut = Screen.height

    // Use this for initialization
    void Start () {
        objectSelected = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonUp(0))
        {
            objectSelected = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (!objectSelected)
            {
                Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject)
                {
                    hitPosition = hit.point;
                    objectSelected = true;
                    firstMousePos = Input.mousePosition;
                    firstCameraPos = this.transform.position;
                }

            } else {
                float newMousePos = Input.mousePosition.y;
                float pourcentTransform;
                if (newMousePos > firstMousePos.y)
                {
                    pourcentTransform = 0.0f;
                } else if (newMousePos < 0.0f) {
                    pourcentTransform = 1.0f;
                } else
                {
                    pourcentTransform = 1 - (newMousePos / firstMousePos.y);
                }
                this.transform.position = firstCameraPos + (hitPosition - firstCameraPos) * pourcentTransform;
            }
        }
    }
}
