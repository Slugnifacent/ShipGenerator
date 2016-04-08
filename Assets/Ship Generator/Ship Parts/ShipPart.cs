using UnityEngine;
using System.Collections;

abstract public class ShipPart : MonoBehaviour {
	protected int Health;
	public tk2dSpriteCollection collection;
	protected tk2dSprite[] sprites;
	protected Color color;
	
	protected virtual void GenerateColor(){
		color = new Color(Random.Range(0,.7f),Random.Range(0,.7f),Random.Range(0,.7f),Random.Range(.1f,.7f));
		
	}
	
	public abstract void Generate();
	
	public virtual void DuplicateToOtherHalf(){
		int childCount = gameObject.transform.GetChildCount();
		for(int index = 0; index < childCount;index++){
			GameObject gObject = (GameObject)Instantiate(gameObject.transform.FindChild(index.ToString()).gameObject);
			Vector3 temp = gObject.transform.localPosition;
			temp.x = -temp.x;
			gObject.transform.localPosition = temp;
			gObject.GetComponent<tk2dSprite>().FlipX();
			gObject.transform.parent = gameObject.transform;
			gObject.renderer.material.SetColor("_Color", color);
		}
	}
	
}
