using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {

	private Text GUI;
	private string guiText;
	private float time;
		
	// Use this for initialization
	void Start () {

		//time = Time.time;
		GUI = gameObject.GetComponent<Text>();
		guiText = "Completion time: " + Time.time;
		GUI.text = guiText;

		//guiText.text = "Some Text Here";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
