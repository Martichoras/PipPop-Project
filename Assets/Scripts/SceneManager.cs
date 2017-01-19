using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public float currentTime;
	//public Canvas SettingsPanel;
	//private GameObject SettingsPanel;
	private bool isActive;
	public float pinAmount;
	private Text pinAmountUpdate;
	private Slider pinSlider;
	private CanvasGroup SettingsCanvasGroup;


	void Start(){

		DontDestroyOnLoad(this); // make this object constant for all scenes i.e. saving

		//Access Pinslider
		if(Application.loadedLevelName == "1_Main"){
		pinSlider = GameObject.Find("PinSlider").GetComponent<Slider>();
		pinAmount = pinSlider.value;
		pinAmountUpdate = GameObject.Find("PinAmountUpdate").GetComponent<Text>();
		}
		// Access and disable Settings canvas
		SettingsCanvasGroup = GameObject.Find("SettingsCanvasGroup").GetComponent<CanvasGroup>();
		//SettingsPanel = GameObject.Find("Settings Canvas").GetComponent<Canvas>();
		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;
		pinAmount = pinAmount;
		//GetTime();
	}


	void FixedUpdate(){
		if(Application.loadedLevelName == "1_Main"){
		pinAmount= pinSlider.value;
		pinAmountUpdate.text = pinAmount.ToString();
		}

		currentTime += Time.deltaTime;
		currentTime = (float)System.Math.Round((double)currentTime,2);
		//GetTime();

		if(Application.loadedLevelName == "1_Main"){
			
			currentTime = 0.0f;
		}


		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}

		//Debug.Log(currentTime);
		//Debug.Log(Time.time);
	
	}

	public void A_Button(){

	Application.LoadLevel("Condition_1_NoSound");
	//Debug.Log("Button pressed");
	}

	public void B_Button(){
		
		Application.LoadLevel("Condition_2_Stereo");
		//Debug.Log("Button pressed");
	}

	public void C_Button(){
		
		Application.LoadLevel("Condition_3_Bineural");
		//Debug.Log("Button pressed");
	}

	public void Restart(){
		
		Application.LoadLevel("1_Main");

		//Debug.Log("Button pressed");
	}

	public void Settings(){
		//GameObject.Find("Settings Canvas").GetComponent<Canvas>().enabled = true;
		//SettingsPanel.enabled = true;
		//GetComponent<Canvas> ().enabled = false;
		SettingsCanvasGroup.alpha = 1;
		SettingsCanvasGroup.blocksRaycasts = true;
	}

	public void SaveSettings(){
		//GameObject.Find("Settings Canvas").GetComponent<Canvas>().enabled = true;
		//SettingsPanel.enabled = false;
		//GetComponent<Canvas> ().enabled = false
		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;
	}


	public float GetTime(){
		
		currentTime += Time.deltaTime;
		//currentTime = System.Math.Round(currentTime,2.0f);

		//return currentTime;
		return (float)System.Math.Round((double)currentTime,2);
	}		

}
