using UnityEngine;
using System.Collections;

public class ShaderEx3 : MonoBehaviour {
	GameObject go;
	float hSliderValue = 0.5f;
	Renderer rend;
	
	void Start () {
		go = new GameObject();
		go.AddComponent<GUIText>();
		go.GetComponent<GUIText>().fontSize = 24;
		go.GetComponent<GUIText>().fontStyle = FontStyle.Normal;
		go.transform.position = new Vector3(0.05f,0.15f);
		go.GetComponent<GUIText>().color =  new Color(0.0f, 0.8f, 0.2f);
		go.GetComponent<GUIText>().enabled = true;
		go.GetComponent<GUIText>().text = "Un fragment shader est un shader qui va avoir pour rôle de calculer la couleur \n\tde tout les pixel de l'image.\n"
            + "Un shader de téssélation est un shader qui va servir à ajouter des points à chaque triangle,\n\t il va servir à ajouter du détail à la scène. ";
		
		rend = GetComponent<Renderer>();

	}
	
	void Update(){
		Debug.Log ("pourcent " + hSliderValue);
		rend.material.SetFloat ("_Pourcent",hSliderValue);
	}
	
	void OnGUI () {
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0F, 1F);
	}
}
