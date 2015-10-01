using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TennerDisplay : MonoBehaviour {
	public enum Status{SUCCESS, FAILURE};

	private Text tennerText;
	private int tenners=100;

	void Start(){
		tennerText = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddTenners (int amount){
		tenners +=amount;
		UpdateDisplay();
//		print (amount +" stars added to display");
	}

	public Status UseTenners (int amount){
		if (tenners>=amount){
		tenners -=amount;
		UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
//		print (amount +" stars removed from");
	}

	private void UpdateDisplay(){
		tennerText.text = tenners.ToString();
	}
}
