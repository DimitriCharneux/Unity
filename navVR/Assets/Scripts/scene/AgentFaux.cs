using UnityEngine;
using System.Collections;

public class AgentFaux : Agent {

	public override bool isTryingToGetKey() {
		return false; //always trying to get keys
	}
	
	public override bool isTryingToOpenDoor() {
		return false; //always trying to open the door
	}
	
	public override Vector3 getCurrentMovement() {
		return transform.TransformDirection( new Vector3(0, 0, 0.0f)); //always moving forward by 0.2 units
	}

	public override bool isInRotation (){
		return true;
	}
	
	public override Vector3 getCurrentRotation() {
		return new Vector3(0, 0.5f, 0); //always rotation 0.5 units
	}
	
	public override void beforeUpdate () {
		// nothing to prepare;
	}
	
	public override void afterUpdate () {
		// nothing to do after update;
	}

}
