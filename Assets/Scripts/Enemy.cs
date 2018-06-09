using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {
	public Transform destination2;
	public Transform destination;
	public Transform player;
	public NavMeshAgent AI;
	public float distanceThreshold = 2;
	public int place1 = 0;
	// Use this for initialization

	void Start () {
		AI = GetComponent<NavMeshAgent>();
		AI.SetDestination (destination.position);

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (AI.remainingDistance);
		if (AI.remainingDistance < distanceThreshold ) {
			if (place1 == 0)
			{
				Debug.Log ("Going place 2");
				place1 = 1;
				AI.SetDestination (destination.position);	
			}else if (place1 == 1){
				Debug.Log ("Going place 1");
				place1 = 0;
				AI.SetDestination (destination2.position);	
			}
			if(place1 == -1)
			{
				AI.SetDestination (player.position);	
			}
		}


	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			Debug.Log ("attack");
			player = col.transform;
			place1 = -1;
		}
	}
}
