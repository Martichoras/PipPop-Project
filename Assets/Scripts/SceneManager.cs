using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public void A_Button(){
	//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	//SceneManager.LoadScene()
	Application.LoadLevel("Condition_1_NoSound");
	//Debug.Log("Button pressed");
	}

	public void B_Button(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//SceneManager.LoadScene()
		Application.LoadLevel("Condition_2_Stereo");
		//Debug.Log("Button pressed");
	}

	public void C_Button(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//SceneManager.LoadScene()
		Application.LoadLevel("Condition_3_Bineural");
		//Debug.Log("Button pressed");
	}

	public void Restart(){
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//SceneManager.LoadScene()
		Application.LoadLevel("1_Main");
		//Debug.Log("Button pressed");
	}



}
