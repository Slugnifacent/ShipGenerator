using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {
	
	public GameObject SpaceInstantiateObject;
	string number;
	bool enter;
	float timer;
	
	
	void Start(){
		number = "Enter Seed";
		Random.seed = System.DateTime.Now.Millisecond;
	}
	
	// Wraps Value around the min and max boundaries/
	static  public T Wrap<T>(T Value, T Min, T Max) where T : System.IComparable<T>
    {
		if (Value.CompareTo(Min) < 0) return Max;
        if (Value.CompareTo(Max) > 0) return Min;
        return Value;
    }
	
	// Update Code for the Input text field
	void Update(){
		timer -= Time.deltaTime;
		foreach( char c in Input.inputString){
			if ( c == 13){	
				enter = true;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) || enter){
			int outValue = 0;
			enter = false;
			if(!int.TryParse(number,out outValue)){
				number = "Invalid Number";
				return;
			}
			Destroy((Object)GameObject.FindGameObjectWithTag("Ship"));
			SpaceInstantiateObject.GetComponent<Ship>().seed = outValue;
			GameObject temp = Instantiate(SpaceInstantiateObject) as GameObject;
			temp.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
			
		}
	}
	
	// Gui Randomizer Button
	void OnGUI(){
		int x = 50;
		int y = 50;
		int width = Screen.width - 2*x;
		int hieght = 20;
		number = GUI.TextField(new Rect(x,y,width,hieght),number);
		if(GUI.Button(new Rect(x,y + 20,100,20),"Random") || timer <= 0){
			number = Random.Range(-2147483647,2147483647).ToString();
			enter = true;
			timer = 1.5f;
		}
	}
}
