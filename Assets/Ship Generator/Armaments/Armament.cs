using UnityEngine;
using System.Collections;

[RequireComponent(typeof(tk2dSprite))]
abstract public class Armament : MonoBehaviour {
	
	public enum Range{Short = 100, Medium = 200, Long = 300};
	
	public Range range;
	public int speed;
	public float accuracy;
	public int damage;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected void Update () {
	
	}
	
	protected abstract void FlightBehavior();
}
