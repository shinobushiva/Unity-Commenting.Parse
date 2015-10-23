using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TogglePanel : MonoBehaviour {

	public Toggle prefab;
	public string[] options;
	private bool[] optionsSelected;

	// Use this for initialization
	void Start () {
		Toggle[] toggles = GetComponentsInChildren<Toggle> ();
		foreach (Toggle t in toggles) {
			DestroyImmediate(t.gameObject);
		}

		optionsSelected = new bool[options.Length];

		int count = 0;
		foreach (string op in options) {
			Toggle t = Instantiate<Toggle> (prefab);
			t.isOn = false;
			t.GetComponentInChildren<Text>().text = op;
			int c = count;
			t.onValueChanged.AddListener((val) => {
				optionsSelected[c] = val;
			});
			t.transform.SetParent(transform, false);
			count++;
		}
	}

	public string[] SelectedOptions(){
		List<string> list = new List<string> ();
		for (int i=0; i<options.Length; i++) {
			if(optionsSelected[i]){
				list.Add (options[i]);
			} 
		}
		return list.ToArray();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
