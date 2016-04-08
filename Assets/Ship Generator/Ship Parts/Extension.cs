using UnityEngine;
using System.Collections;

public class Extension : ShipPart {

		public override void Generate ()
		{	
		    // Grabs Ship information
			GenerateColor();
			int id = gameObject.transform.parent.GetComponent<Ship>().GetID();
			int Size = gameObject.transform.parent.GetComponent<Ship>().GetSize();
			int extentsionCount = (int)Random.Range(1,Size);
			for(int index = 0; index < extentsionCount; index++){
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
				// Place in the middle of selected MidSection
				int choice = (int)Random.Range(0,Size);
				Transform midSection = gameObject.transform.parent.FindChild("MidSection").GetChild(choice);
				Vector3 spacing = midSection.GetComponent<tk2dSprite>().GetBounds().size/3;
				spacing.y = - spacing.y;
				spacing.z = .015f;
				temp.transform.localPosition = midSection.position + spacing;
				id++;
			    temp.renderer.material.SetColor("_Color", color);
			}
			DuplicateToOtherHalf();
		}
	
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
