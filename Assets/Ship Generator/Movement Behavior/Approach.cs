using UnityEngine;
using System.Collections;

public class Approach : MovementBehavior {
	public int ApproachDistance;
	public float ApproachSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected override void Update () {
		Vector3 direction = (target.transform.position - gameObject.transform.position);

		if(Vector3.Distance(target.transform.position , gameObject.transform.position) < ApproachDistance){
			  gameObject.transform.position += direction*ApproachSpeed;
		}else gameObject.transform.position += direction.normalized*speed;
	}
}
