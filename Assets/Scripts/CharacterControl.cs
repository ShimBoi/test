using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterControl : MonoBehaviour {
	Rigidbody rigidbody;
	public float moveSpeed ;
	public float jumpSpeed = 150;
	public int health = 100;
	public Slider healthBar;
	public Text healthText;
	public Text DieScreen;
	string maxHelath;
	bool onGround = false;

	public int Health {
		get{return health;}
		set{
			health = value;
			if(health>maxHelath){
				health = maxHelath;
				return
			}
			healthBar.value = health;
			Debug.Log (health);
			healthText.text = health + "/"+maxHelath;
			if (health <= 0) {
				DieScreen.text = "You Died";
				healthText.text = "0/" + maxHelath;
			}
		}

	}

	// Use this for initialization
	void Start () {
		rigidbody = gameObject.GetComponent<Rigidbody> ();
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
		maxHelath = ""+health;
		healthBar.maxValue = health;
		healthText.text= health +"/"+maxHelath ;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.P)){
			Health += 2;
		}

		if(onGround == true){
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
				rigidbody.AddRelativeForce (Vector3.up* jumpSpeed);
				onGround = false;
			}
				
		}
		if (onGround == false){
			
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
	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("rabbit")) {
			Health -= 3;

		}

	}

}
