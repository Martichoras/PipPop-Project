using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

	public float distance;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this); // make this object constant for all scenes i.e. saving
	}
	
	// Update is called once per frame
	void Update () {

		// THIS WORKS!
		transform.position = Camera.main.transform.position + Camera.main.transform.rotation * Vector3.forward * distance;
	}
}
