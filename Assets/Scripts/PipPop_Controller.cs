﻿using UnityEngine;
using System.Collections;

public class PipPop_Controller : MonoBehaviour {

	private GameObject sphere;
	private Vector3 spawnPoint;
	private float sphereRadius;
	private GameObject sphereScript;
	private float spawnHeight;
	private float adjuster;
	private float distanceBetweenPoints;
	private float distanceProximity;

	private GameObject Scriptholder;
	private bool isProximityDependent;


	AudioSource audio;

	// SCENE MANAGEMENT
	private string currentScene;
	//private Vector3  spawnPoint;

	// Material variables
	[Range(0.5f,2.0f)]
	private float blinkFrequency;

	public Material material1;
	public Material material2;

	public float min = 1.0f;
	//public float max = 10.0f;

	// Use this for initialization
	void Start () {
		//sceneManager = GameObject.Find("Scriptholder");
		currentScene = Application.loadedLevelName;
		Debug.Log(currentScene);

		//spawnPoint = GetRandomPointOnSphere();
		while(spawnPoint == Vector3.zero || spawnPoint.y > (spawnHeight * sphereRadius)){ // keep finding spawnpoint lower than spawnHeight
			spawnPoint = GetRandomPointOnSphere();										//
		}

		Debug.Log("Spawnpoint = "+spawnPoint);

		gameObject.transform.position = spawnPoint;
		transform.LookAt(Vector3.zero); // orientation towards origo
		transform.Rotate(0, 0, 90); // horizontally alligned

		Scriptholder = GameObject.Find("Scriptholder");
		isProximityDependent = Scriptholder.GetComponent<SceneManager>().isProximityDependent;
		blinkFrequency = Scriptholder.GetComponent<SceneManager>().blinkFrequency;
		//Debug.Log("PipPop-pin spawn location: "+spawnPoint);
		StartCoroutine(flasher());
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//blinkFrequency = blinkFrequency/DistanceBetweenPoints();
		//Debug.Log(DistanceBetweenPoints());
		Debug.Log(DistanceProximity());
	}

	IEnumerator flasher(){
		//string currentScene =
		AudioSource audio = GetComponent<AudioSource>();
		switch(currentScene){
			
		// Condition 1 CHANGES HERE
		case "Condition_1_NoSound":
			//AudioSource audio = GetComponent<AudioSource>();
			while(true){
			GetComponent<MeshRenderer>().material = material1;
				//audio.Play();
				yield return new WaitForSeconds(DistanceProximity());
			GetComponent<MeshRenderer>().material = material2;
				//audio.Play();
				yield return new WaitForSeconds(DistanceProximity());
		}
			break;

		// Condition 2 CHANGES HERE
		case "Condition_2_Stereo":
			//AudioSource audio = GetComponent<AudioSource>();
			while(true){
				GetComponent<MeshRenderer>().material = material1;
				audio.Play();
				//yield return new WaitForSeconds((blinkFrequency*DistanceBetweenPoints())/(sphereRadius*2));
				yield return new WaitForSeconds(DistanceProximity());
				GetComponent<MeshRenderer>().material = material2;
				audio.Play();
				yield return new WaitForSeconds(DistanceProximity());
			}
			break;
		
		// Condition 3 CHANGES HERE
		case "Condition_3_Bineural": 
			//AudioSource audio = GetComponent<AudioSource>();
			while(true){
				GetComponent<MeshRenderer>().material = material1;
				audio.Play();
				yield return new WaitForSeconds(DistanceProximity());
				GetComponent<MeshRenderer>().material = material2;
				audio.Play();
				yield return new WaitForSeconds(DistanceProximity());
			}
			break;
		}
	}

	Vector3 GetRandomPointOnSphere(){
		Vector3 spawnPoint;

		sphere = GameObject.Find("Pip_pop_sphere");
		spawnHeight = sphere.GetComponent<PinSpawner>().spawnHeight; // sets this spawn height to same as user-defined
		sphereRadius = (sphere.transform.localScale.x/2); // finds radius i.e. scale / 2
		spawnPoint = sphere.GetComponent<Rigidbody>().velocity = Random.onUnitSphere * sphereRadius;
		spawnPoint.y = Mathf.Abs(spawnPoint.y); // another way of assuring no -y instantiations i.e. absolute value of y / opløfter fortegn

		return spawnPoint;
	}


	float DistanceProximity(){ // This function increases/decrease the sound/material change depending on proximity to target

		Vector3 x = GameObject.FindGameObjectWithTag("Tracker").GetComponent<Transform>().position;
		Vector3 y = this.transform.position;

		distanceBetweenPoints = Vector3.Distance(x,y);
		distanceProximity = Mathf.Clamp((blinkFrequency*distanceBetweenPoints)/(sphereRadius*2),0.1f,sphereRadius*2);
		//return Mathf.Clamp(Vector3.Distance(x,y),4,sphereRadius*2);
		//(blinkFrequency*distanceBetweenPoints)/(sphereRadius*2);
		//Debug.Log(distanceProximity);
		if(isProximityDependent){
			return distanceProximity;
		} else {
			return blinkFrequency;
		}
	}

}
