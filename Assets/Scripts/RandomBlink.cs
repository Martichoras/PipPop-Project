using UnityEngine;
using System.Collections;

public class RandomBlink : MonoBehaviour {

	public Material material1;
	public Material material2;

	private float blinkFrequency;
	private bool isTrue = true;
	public bool distractors;
	private GameObject Scriptholder;
	// Use this for initialization
	void Start () {

		Scriptholder = GameObject.Find("Scriptholder");
		distractors = Scriptholder.GetComponent<SceneManager>().useDistractors;



		if(distractors){
			StartCoroutine(Flasher());
			//Debug.Log("Distractors are enabled");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Flasher(){
		while(isTrue){
		blinkFrequency = Random.Range(1,10);

		GetComponent<MeshRenderer>().material = material1;
		yield return new WaitForSeconds(blinkFrequency);
	
		blinkFrequency = Random.Range(1,10);

		GetComponent<MeshRenderer>().material = material2;
		yield return new WaitForSeconds(blinkFrequency);
		}
	}
		
}

