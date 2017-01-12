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
		//guiText = "Completion time: "+Time.time;
		completionTimeText.text = "Completion time: "+currentTime.ToString();
	
	}
		
}
