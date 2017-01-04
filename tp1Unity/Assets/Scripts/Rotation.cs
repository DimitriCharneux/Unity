using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public float rotationAngle = 1.0f;
	// Use this for initialization
	void Start () {
		Debug.Log ("your object is " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3(0,1,0), rotationAngle);
	}
}
