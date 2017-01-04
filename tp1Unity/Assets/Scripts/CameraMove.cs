using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public GameObject cible;
	public float rotationAngle = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (cible.transform.position ,Vector3.up, rotationAngle);
	}
}
