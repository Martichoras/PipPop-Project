using UnityEngine;
using System.Collections;

public class PinController : MonoBehaviour {

	private int[] angle = new int[12] {15,20,30,60,70,75,-15,-20,-30,-60,-70,-75};
	private int random;
	private int localAngle;
	//private Vector3 rot;

	//private GameObject sphere;

	// Use this for initialization
	void Start () {
		
		random = Random.Range(0,12);
		localAngle = angle[random];

		transform.LookAt(Vector3.zero);

		transform.Rotate(0, 0, localAngle);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		
		if(col.gameObject.tag == "Pin"){
			Destroy(gameObject);
			//Debug.Log("Object destroyed!");
		} else if(col.gameObject.tag == "PipPopPin"){
			Destroy(this.gameObject);
			Debug.Log("Pip-Pop Pin destroyed other pin!");
		}
	}
}
