using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public float currentTime;

	void Start(){

		DontDestroyOnLoad(this);
		//GetTime();
	}


	void FixedUpdate(){

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

	public float GetTime(){
		
		currentTime += Time.deltaTime;
		//currentTime = System.Math.Round(currentTime,2.0f);

		//return currentTime;
		return (float)System.Math.Round((double)currentTime,2);
	}		

}
