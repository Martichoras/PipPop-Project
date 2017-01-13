using UnityEngine;

public class Rotate : MonoBehaviour 
{
	void Update() 
	{
		// Rotate the object around its local X axis at 1 degree per second
		transform.Rotate(-Vector3.forward * Time.deltaTime*50.0f);

		// ...also rotate around the World's Y axis
		//transform.Rotate(Vector3.out * Time.deltaTime*10.0f, Space.World);
	}
}