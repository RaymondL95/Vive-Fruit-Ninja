using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropdownFunctions : MonoBehaviour {
    private Object[] _ListOfNames;
    [SerializeField] Dropdown dropdown;
    int count;
	// Use this for initialization
	void Start () {
        //list called names
        List<string> names = new List<string>();
        //array of audioclips
        _ListOfNames = Resources.LoadAll("Sound", typeof(AudioClip));
        foreach(AudioClip i in _ListOfNames)
        {
            //add each audioclip name into list
            names.Add(i.name);
        }
        //add each list element into dropdown
        dropdown.AddOptions(names);
        Debug.Log("names.count=" + names.Count);
        count = names.Count;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
