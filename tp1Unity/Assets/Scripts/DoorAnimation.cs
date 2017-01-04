using UnityEngine;
using System.Collections;

public class DoorAnimation : MonoBehaviour {
	private bool ferme = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Animation anim = GetComponent<Animation> ();
		if (Input.GetButtonDown ("Fire1") && ferme && !anim.isPlaying) {
			ferme = false;
			anim.Play ("door-open");
		}
		if (Input.GetButtonDown ("Fire2") && !ferme && !anim.isPlaying) {
			ferme = true;
			anim.Play ("door-close");
		}
	}
}
