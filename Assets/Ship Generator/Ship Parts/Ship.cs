using UnityEngine;
using System;
using System.Collections;

public class Ship : MonoBehaviour {
	int id;
	int size;
	public int seed;
	
	int hullHealth;
	int shields;
	int speed;
	int MovementRange;
	
	
	// Use this for initialization
	void Awake () {
		UnityEngine.Random.seed = seed;
		
		id = UnityEngine.Random.Range(0,22);
		size = UnityEngine.Random.Range(1,5);
		gameObject.tag = "Ship";
		transform.FindChild("MidSection").GetComponent<MidSection>().Generate();
		transform.FindChild("Extension").GetComponent<Extension>().Generate();
		transform.FindChild("Weapon").GetComponent<Weapon>().Generate();
		transform.FindChild("Engine").GetComponent<Engine>().Generate();
		transform.localScale = new Vector3(100,100,0);
		
		
		hullHealth = 100;
		shields = 100;
		speed = 5;
		MovementRange = 50;
		
	}
	
	public int GetID(){
		return id;
	}
	
	public int GetSize(){
		return size;
	}
	
	public void TakeDamage(int Damage,bool ArmorPiercing){
		if(ArmorPiercing){
			hullHealth -= Damage;
		}
		else {
			shields -= Damage;
			if(shields < 0){
				hullHealth += shields;
				shields = 0;
			}
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool Alive(){
		return hullHealth > 0;
	}
}
