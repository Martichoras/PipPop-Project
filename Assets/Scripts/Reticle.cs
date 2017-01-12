using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

	//public Camera camera;
	private Vector3 initialScale;
	public bool pinFound = false;

	void Start () {
		pinFound = false;
		initialScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

		// a stereoscopic image of reticle is that it creates a double image making it hard to aim.
		RaycastHit hit;
		float distance;
		if (Physics.Raycast (new Ray(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward), out hit)) {
			distance = hit.distance;
		} else { 
			distance = Camera.main.farClipPlane * 0.95f; //
		}

		transform.LookAt (Camera.main.transform.position); //rotate towards the camera
		transform.Rotate(0.0f, 180.0f,0.0f); // Reticle is a quad, so it needs to be reversed so the 'normal' side is visible
		transform.position = Camera.main.transform.position + Camera.main.transform.rotation * Vector3.forward * distance;
		transform.localScale = initialScale * distance; // sets scale of quad by the original scale*dist. scaling is performed linarly with with distance

		if(hit.rigidbody != null){
			if(hit.rigidbody.tag == "PipPopPin" && Input.GetMouseButtonDown(0)){
				Debug.Log("- Pin found! -\nTime: "+Time.time);
				pinFound = true;
			} else if(hit.rigidbody.tag == "Pin" && Input.GetMouseButtonDown(0)){
				Debug.Log("- Wrong pin chosen - \nPin name: "+hit.rigidbody.name+"\nPin orientation: "+hit.rigidbody.transform.localEulerAngles+"\nTime: "+Time.time);

			}
		}

		if(pinFound){
			Application.LoadLevel("2_Final");
			Debug.Log("Quitting"); //Or go to scene
		}

	}
}
