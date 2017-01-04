using UnityEngine;
using System.Collections;

public class ShaderEx2 : MonoBehaviour {
	GameObject go;
	float hSliderValue = 0.0f;
	Renderer rendHead, rendArms, rendBody;
	
	void Start () {
		go = new GameObject();
		go.AddComponent<GUIText>();
		go.GetComponent<GUIText>().fontSize = 24;
		go.GetComponent<GUIText>().fontStyle = FontStyle.Normal;
		go.transform.position = new Vector3(0.05f,0.1f);
		go.GetComponent<GUIText>().color =  new Color(0.0f, 0.8f, 0.2f);
		go.GetComponent<GUIText>().enabled = true;
		go.GetComponent<GUIText>().text = "Un vertex shader est un shader qui va utiliser une transformation géométrique\n\t pour projeter un sommet à l'écran";

		rendHead = GameObject.Find("head").GetComponent<Renderer>();
		rendArms = GameObject.Find("armorArms").GetComponent<Renderer>();
		rendBody = GameObject.Find("armorBody").GetComponent<Renderer>();
	}
	
	void Update(){
		Debug.Log ("pourcent " + hSliderValue);
		rendHead.material.SetFloat ("_Pourcent",hSliderValue);
		rendArms.material.SetFloat ("_Pourcent",hSliderValue);
		rendBody.material.SetFloat ("_Pourcent",hSliderValue);
	}
	
	void OnGUI () {
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, -0.03F, 0.03F);
	}
}
