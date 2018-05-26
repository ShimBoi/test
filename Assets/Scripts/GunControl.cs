using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {
	public GameObject bulletPrefab;
	public Transform barrelTip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			GameObject newBullet = Instantiate (bulletPrefab, barrelTip.position, barrelTip.rotation);
			newBullet.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * 1000);
		
		}

	}
}
