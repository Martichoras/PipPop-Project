using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeUpdate : MonoBehaviour {

	private Text completionTimeText;
	private string guiText;
	private float currentTime;
	private GameObject Scriptholder;
		
	// Use this for initialization
	void Start () {

		//DontDestroyOnLoad(this);

		completionTimeText = GameObject.Find("Completion").GetComponent<Text>();
		Scriptholder = GameObject.Find("Scriptholder");
		currentTime = Scriptholder.GetComponent<SceneManager>().GetTime();
		completionTimeText.text = "Completion time: "+currentTime.ToString();
	
	}

	public void Restart(){

		Application.LoadLevel("1_Main");

		//Debug.Log("Button pressed");
	}

	public void Quit(){
		Application.Quit();
		Debug.Log("Quitting program...");
	}
		
}
