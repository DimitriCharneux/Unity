using UnityEngine;
using System.Collections;

public class GuitextShaderEx1 : MonoBehaviour {

	GameObject go;
	float hSliderValue = 0.0f;
	Renderer rend;

	void Start () {
		go = new GameObject();
		go.AddComponent<GUIText>();
		go.GetComponent<GUIText>().fontSize = 24;
		go.GetComponent<GUIText>().fontStyle = FontStyle.Normal;
		go.transform.position = new Vector3(0.05f,0.2f);
		go.GetComponent<GUIText>().color =  new Color(0.0f, 0.8f, 0.2f);
		go.GetComponent<GUIText>().enabled = true;
		go.GetComponent<GUIText>().text = "Un shader est un bout de code exécuté sur le GPU qui modifie le rendu des objets 3D.\n"+
            "Un Shader de surface est un type de shader qui va changer la surface d'un objet \n\t(sa couleur, sa transparence, etc)\n"
            +"Une propriété est un objet que l'ont va donner au shader pour qu'il l'utilise, \n\tça peut être un float par exemple.\n"
            +"Pour accéder à une propriété, on utilise le renderer pour envoyer l'objet.";

		rend = GetComponent<Renderer>();
	}

	void Update(){
		rend.material.SetFloat ("_Pourcent",hSliderValue);
	}

	void OnGUI () {
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 1.0F);
	}
}
