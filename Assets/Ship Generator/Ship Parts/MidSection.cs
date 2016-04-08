using UnityEngine;
using System.Collections;

public class MidSection : ShipPart {
	
	public Texture2D texture; 
	
	
	
	
	public override void Generate ()
	{	
		// Grabs Ship information
		int id = gameObject.transform.parent.GetComponent<Ship>().GetID();
		int Size = gameObject.transform.parent.GetComponent<Ship>().GetSize();
		float ShipHeight = 0;
		GenerateColor();
		for(int index = 0; index < Size; index++){
			// Add gameobject and sprite component
			GameObject temp = new GameObject();
			temp.name = index.ToString();
			temp.transform.parent = gameObject.transform;
			temp.AddComponent<tk2dSprite>();
			tk2dSprite tempSprite = temp.GetComponent<tk2dSprite>();
			
			// Find Suitable ID
			id = Utility.Wrap<int>(id,0,collection.spriteCollection.spriteDefinitions.Length-1);
			while(collection.spriteCollection.spriteDefinitions[id].name == ""){
				id += (int)Random.Range(0,4);
				id = Utility.Wrap<int>(id,0,collection.spriteCollection.Count-1);
			}
			
			// Create Sprite
			tempSprite.SwitchCollectionAndSprite(collection.spriteCollection,id);
			tempSprite.Build();	
			
			
			// Choose Location to position new Sprite
			// Based on the progress of the height of the ship, place a 
			// sprite just above the previously placed midsection sprite.
			float randomNumber = 0;
			float heightSpace = 0;
			if(ShipHeight != 0){
				heightSpace = ShipHeight + tempSprite.GetBounds().size.y;
				randomNumber = Random.Range(heightSpace-heightSpace/5 , heightSpace-heightSpace/9);
				ShipHeight += randomNumber - ShipHeight;
			}else {
				ShipHeight += tempSprite.GetBounds().size.y;
				randomNumber = Random.Range(ShipHeight/5, Mathf.Abs(ShipHeight-ShipHeight/9));

				temp.transform.localPosition = new Vector3(0,.1f,.025f + index*.025f);
				id += (int)Random.Range(0,4);
				temp.renderer.material.SetColor("_Color", color);
				continue;
			}
			temp.transform.localPosition += new Vector3(0,randomNumber,.025f + index*.025f);
			id += (int)Random.Range(0,4);	
			temp.renderer.material.SetColor("_Color", color);
		}
		DuplicateToOtherHalf();
	} 
	

	
	// Update is called once per frame
	void Update () {
	
	}
}
