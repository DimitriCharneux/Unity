using UnityEngine;
using System.Collections;

public class AgentExample : Agent {

	/*--- pour la rotation ---*/
	public float speed = 5.0f;
	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;
	
	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 180.0f;
	bool demiTour = false;
	int tmpDemiTour = 0;
	public int fpsDemiTour;

	/*--- pour le déplacement ---*/
	public GameObject light;
	public int fpsDash;
	bool firstClick = false, dash = false;
	int tmpDash = 0;
	float speedOfLight;
	Vector3 oldPosition, startPosition, pasDash;



	public override bool isTryingToGetKey() {
		return true; //always trying to get keys
	}
	
	public override bool isTryingToOpenDoor() {
		return true; //always trying to open the door
	}
	
	public override Vector3 getCurrentMovement() {
		if(dash){
			tmpDash ++;
			if(tmpDash > fpsDash){
				tmpDash = 0;
				dash = false;
			}
			return pasDash;
		}
		return new Vector3 (0,0,0);
	}

	public override bool isInRotation (){
		return demiTour || Input.GetAxis ("Mouse ScrollWheel") < 0 || Input.GetMouseButton (1);
	}

	public override Vector3 getCurrentRotation() {
		Vector3 result = new Vector3 (0,0,0);
		if(Input.GetAxis ("Mouse ScrollWheel") < 0){
			demiTour = true;
		}
		if(demiTour){
			tmpDemiTour++;
			if(tmpDemiTour >= fpsDemiTour){
				tmpDemiTour = 0;
				demiTour = false;
			}
			rotationX += 180 / fpsDemiTour;
			return new Vector3(-rotationY,rotationX,0);
		}

		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		result = new Vector3 (-rotationY, rotationX, 0);
		return result;
	}
	
	public override void beforeUpdate () {
		speedOfLight = Time.deltaTime*2;
		if (Input.GetMouseButton (0)) {
			if(!firstClick){
				firstClick = true;
				oldPosition = Input.mousePosition;
				Vector3 addPos = transform.rotation * new Vector3(0,0,2);
				addPos.y = 0;
				startPosition = transform.position + addPos + new Vector3(0,1,0);
			} else {
				Vector3 newPosition = Input.mousePosition;
				Vector3 diff = newPosition - oldPosition;
				if(diff.y < -100f){
					diff.y = -100f;
					oldPosition.y = newPosition.y +100f;
				}
				Vector3 addDist = transform.rotation * new Vector3(diff.x * speedOfLight, 0, diff.y * speedOfLight);
				addDist.y = 0;
				light.transform.position = startPosition + addDist;
			}
			light.light.enabled = true;
		} else {
			if(firstClick){
				dash = true;
				pasDash = (light.transform.position - transform.position)/fpsDash;
				light.light.enabled = false;
				firstClick = false;
			}
		}
	}
	
	public override void afterUpdate () {
		if(Input.GetKey("r")){
			rotationY = 0.0f;
			rotationX = 180.0f;
		}
	}

}
