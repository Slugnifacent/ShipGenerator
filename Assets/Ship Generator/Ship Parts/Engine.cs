using UnityEngine;
using System.Collections;

public class Engine : ShipPart {
	
	public override void Generate ()
	{	
		// Grabs Ship information
		GenerateColor();
		int id = gameObject.transform.parent.GetComponent<Ship>().GetID();

		for(int index = 0; index < 1; index++){
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
			// Place in the middle of selected first Midsection
			Transform midSection = gameObject.transform.parent.FindChild("MidSection").GetChild(0);
			Vector3 spacing = midSection.GetComponent<tk2dSprite>().GetBounds().size;
			spacing.y = -spacing.y + .01f;
			spacing.x = spacing.z = 0;
			temp.transform.localPosition = midSection.position + spacing;
			temp.renderer.material.SetColor("_Color", color);
		}
		 
		DuplicateToOtherHalf();
	} 
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
