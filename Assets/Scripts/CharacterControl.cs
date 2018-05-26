using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {
	Rigidbody rigidbody;
	public float moveSpeed ;



	bool onGround = false;

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody> ();
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.L)) {
			Debug.Log ("hit");
		}
		if(Input.GetKey(KeyCode.W)){
			rigidbody.AddRelativeForce (Vector3.forward * moveSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			rigidbody.AddRelativeForce (Vector3.back * moveSpeed);
		}
		if(Input.GetKey(KeyCode.A)){
			rigidbody.AddRelativeForce (Vector3.left* moveSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			rigidbody.AddRelativeForce (Vector3.right* moveSpeed);
		}
		if(Input.GetKey(KeyCode.Space) && onGround){
			rigidbody.AddRelativeForce (Vector3.up* 100);
			onGround = false;
		}


	}



	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.CompareTag ("trigger")) {
			Debug.Log ("hit");
		}
		if (col.gameObject.CompareTag("terrain")) {
			onGround = true;
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("trigger")) {
			Debug.Log ("keep hitting");
			transform.position =  new Vector3 (90f, 90f);
		} 
	}

}
