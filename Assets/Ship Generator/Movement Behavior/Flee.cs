using UnityEngine;
using System.Collections;

public class Flee : MovementBehavior {

	
	// Use this for initialization
	void Start () {
	
	}
	
	
	// Update is called once per frame
	protected override void Update () {
		Vector3 direction = (target.transform.position - gameObject.transform.position);
		gameObject.transform.position -= direction.normalized*speed;
	}
}
