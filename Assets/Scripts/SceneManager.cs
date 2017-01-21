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
	public float blinkFrequency;
	private Text pinAmountUpdate;
	private Text freqAmountUpdate;
	private Slider pinSlider;
	private Slider freqSlider;
	private CanvasGroup SettingsCanvasGroup;
	private CanvasGroup ConditionCanvasGroup;

	public bool useDistractors;
	public bool isProximityDependent;


	void Start(){

		DontDestroyOnLoad(this); // make this object constant for all scenes i.e. saving

		//Access Pinslider
		if(Application.loadedLevelName == "1_Main"){
			pinSlider = GameObject.Find("PinSlider").GetComponent<Slider>();
			pinAmount = pinSlider.value;
			pinAmountUpdate = GameObject.Find("PinAmountUpdate").GetComponent<Text>();

			freqSlider = GameObject.Find("FreqSlider").GetComponent<Slider>();
			blinkFrequency = freqSlider.value;
			freqAmountUpdate = GameObject.Find("FreqAmountUpdate").GetComponent<Text>();
		}

		// Access and disable Settings canvas
		SettingsCanvasGroup = GameObject.Find("SettingsCanvasGroup").GetComponent<CanvasGroup>();
		//SettingsPanel = GameObject.Find("Settings Canvas").GetComponent<Canvas>();
		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;

		ConditionCanvasGroup = GameObject.Find("ConditionCanvasGroup").GetComponent<CanvasGroup>();
		//SettingsPanel = GameObject.Find("Settings Canvas").GetComponent<Canvas>();
		//ConditionCanvasGroup.alpha = 0;
		//ConditionCanvasGroup.blocksRaycasts = false;

		//pinAmount = pinAmount;
		//blinkFrequency = blinkFrequency;

	}


	void FixedUpdate(){
		if(Application.loadedLevelName == "1_Main"){
			pinAmount= pinSlider.value;
			pinAmountUpdate.text = pinAmount.ToString();

			blinkFrequency = freqSlider.value;
			blinkFrequency = (float)System.Math.Round((double)blinkFrequency,2);
			freqAmountUpdate.text = blinkFrequency.ToString();
		}

		currentTime += Time.deltaTime;
		currentTime = (float)System.Math.Round((double)currentTime,2);
		//GetTime();

		if(Application.loadedLevelName == "1_Main"){

			// GET DISTRACTOR BOOL
			useDistractors = GameObject.Find("DistractorToggle").GetComponent<Toggle>().isOn;
			// USE PROXIMITY BOOL
			isProximityDependent = GameObject.Find("ProximityToggle").GetComponent<Toggle>().isOn;
			currentTime = 0.0f;
		}


		if(Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}


	
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

		ConditionCanvasGroup.alpha = 0;
		ConditionCanvasGroup.blocksRaycasts = false;

		SettingsCanvasGroup.alpha = 1;
		SettingsCanvasGroup.blocksRaycasts = true;
	}

	public void SaveSettings(){

		SettingsCanvasGroup.alpha = 0;
		SettingsCanvasGroup.blocksRaycasts = false;

		ConditionCanvasGroup.alpha = 1;
		ConditionCanvasGroup.blocksRaycasts = true;
	}


	public float GetTime(){
		
		currentTime += Time.deltaTime;
		//currentTime = System.Math.Round(currentTime,2.0f);

		//return currentTime;
		return (float)System.Math.Round((double)currentTime,2);
	}
				

}
