using UnityEngine;
using System.Collections;

abstract public class MovementBehavior : MonoBehaviour {
	public Transform target;
	public float speed;
	protected abstract void Update();
}
