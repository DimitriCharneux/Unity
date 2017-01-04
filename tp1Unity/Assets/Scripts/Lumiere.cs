using UnityEngine;
using System.Collections;

public class Lumiere : MonoBehaviour {
	public GameObject light;
    public GameObject audio;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Animator anim = GetComponent<Animator>() ;
		AnimatorStateInfo si=anim.GetCurrentAnimatorStateInfo (0);
		Light li = light.GetComponent<Light> ();
        AudioSource aud = audio.GetComponent<AudioSource> ();
        li.intensity = 0;
		if (si.IsName ("Burn")) {
			li.intensity = Random.value * 8;
            if(!aud.isPlaying)
                aud.Play();
		} else {
            aud.Stop();
        }
	}
}
