using UnityEngine;
using System.Collections;

public class SoldierAnimation : MonoBehaviour {
	public float speed = 1.0f;
	public float angle = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Animation anim = GetComponent<Animation> ();
		anim.CrossFade("soldierIdleRelaxed");
		if (Input.GetKey(KeyCode.LeftArrow)) {
			anim.CrossFade("soldierSpinLeft");
			this.transform.Rotate(new Vector3(0,1,0), angle);
		} 
		if (Input.GetKey(KeyCode.RightArrow)) {
			anim.CrossFade("soldierSpinRight");
			this.transform.Rotate(new Vector3(0,-1,0), angle);
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			anim.CrossFade("soldierRun");
			this.transform.Translate(Time.deltaTime * Vector3.forward * speed);
		} 
		if (Input.GetKey(KeyCode.DownArrow)) {
			anim["soldierWalk"].speed = -1;
			this.transform.Translate(-1 * Time.deltaTime * Vector3.forward * speed);
			anim.CrossFade("soldierWalk");
		} 
	}
}
