using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
	private TennerDisplay tennerDisplay;

	void Start(){
		defenderParent = GameObject.Find("Defenders");
		tennerDisplay = GameObject.FindObjectOfType<TennerDisplay>();
	

		if (defenderParent == null){
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() {
		GameObject defender = Buttons.selectedDefender;

		if (tennerDisplay.UseTenners(defender.GetComponent<Defender>().tennerCost)==TennerDisplay.Status.SUCCESS)
		{
		Vector2 rawPos=CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid(rawPos);
		Quaternion rotation = Quaternion.identity;
		GameObject newDefender = Instantiate (defender, roundedPos, rotation) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
		}else {Debug.Log("not enough tenners");}

	}

	
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX,newY,oldX,oldY;
		oldX=rawWorldPos.x;
		oldY=rawWorldPos.y;
		newX=Mathf.Round(oldX);
		newY=Mathf.Round(oldY);

		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3(mouseX,mouseY,distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

		return worldPos;
	}
}
