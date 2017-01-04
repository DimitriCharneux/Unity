using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

[ExecuteInEditMode]
public class DistanceField3D : MonoBehaviour {
	string[] toolbarStrings = {"Intersection", "Iterations", "Lighting", "Shadowing"};
	int toolbarInt=0 ;
	bool doDiff=false ;
	public Light l ;

	class Particule
	{
		float x,y,z ;
		float vx,vy, vz ;

		public Particule(){
			x=Random.value ;
			y=Random.value ;
			z=Random.value ;

			vx=Random.value/200 ;
			vy=Random.value/200 ; 
			vz=Random.value/200 ; 
		}

		public void update(){
			if (x > 1.0 || x < 0.0) {
				vx = -vx;
				x+=vx;
			}
			if (y > 1.0 || y < 0.0) {
				vy = -vy;
				y+=vy;
			}

			if (z > 1.0 || z < 0.0) {
				vz = -vz;
				z+=vz;
			}

			x += vx ;
			y += vy ;
			z += vz ;
		}

		public byte getX(){ return (byte)(x*254); }
		public byte getY(){ return (byte)(y*254); }
		public byte getZ(){ return (byte)(z*254); }
	}

	List<Particule> particules ;

	// Use this for initialization
	void Start () {
		Texture2D tx=renderer.sharedMaterial.GetTexture("_Positions") as Texture2D;

		particules = new List<Particule> () ;
		for (int i=0; i<tx.width; i++) {
			particules.Add(new Particule());
		}
	}
	
	// Update is called once per frame
	void Update () {
		Texture2D tx=renderer.sharedMaterial.GetTexture("_Positions") as Texture2D;

		if (particules==null) {
			particules = new List<Particule> () ;
			for (int j=0; j<tx.width; j++) {
				particules.Add(new Particule());
			}
		
		}


		Matrix4x4 matrix=Camera.main.projectionMatrix*Camera.main.worldToCameraMatrix;
		Matrix4x4 invmvp=matrix.inverse;
		
		renderer.sharedMaterial.SetMatrix("_InvMVP", invmvp);
		renderer.sharedMaterial.SetMatrix("_MVP", matrix);
		
		renderer.sharedMaterial.SetFloat("_Near", Camera.main.near);
		renderer.sharedMaterial.SetFloat("_Far", Camera.main.far);
		
		renderer.sharedMaterial.SetVector("_LightPos", l.transform.position);
		renderer.sharedMaterial.SetVector("_EyePosition", Camera.main.transform.position);

		if (!tx)
			return; 

		int i = 0;
		foreach (Particule p in particules) {
			p.update() ;
			if (i < tx.width) {
				tx.SetPixel (i, 0, new Color32 (p.getX(), p.getY (), p.getZ (), 255)) ;
			} 
			i+=1 ;
		}
		tx.Apply();
	}

	void OnGUI(){
		toolbarInt = GUI.Toolbar (new Rect (25, 350, 480, 30), toolbarInt, toolbarStrings) ;
		doDiff = GUI.Toggle (new Rect (25, 390, 100, 30), doDiff, "Subtract Spheres") ;
		renderer.sharedMaterial.SetInt ("_Mode", toolbarInt) ; 
		if(doDiff)
			renderer.sharedMaterial.SetInt ("_DoUnion", 0) ;
		else
			renderer.sharedMaterial.SetInt ("_DoUnion", 1) ;
	}
}
