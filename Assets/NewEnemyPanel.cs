using UnityEngine;
using System.Collections;

public class NewEnemyPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("DestroyGameObjectPanel", 3F);
	}
	void DestroyGameObjectPanel(){
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
