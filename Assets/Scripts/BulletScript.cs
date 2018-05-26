using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public float TimeToDie = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		TimeToDie += Time.deltaTime;
		if (TimeToDie >= 5){
			Destroy (gameObject);
		}

	}
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.CompareTag ("bullet")) {
			Debug.Log ("hit");
		
	}
}
}
