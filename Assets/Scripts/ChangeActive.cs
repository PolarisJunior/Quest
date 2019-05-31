using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Event to transition between object active/inactive
public class ChangeActive : EventTrigger {

    public GameObject Sphere1;
    public GameObject Sphere2;
    private bool _state;

    public /* override*/ void Activate()
    {
        _state = !_state;
        Sphere1.SetActive(_state);
        Sphere2.SetActive(!_state);
    }

    public /* override*/ void Activate(bool state)
    {
        _state = state;
        Sphere1.SetActive(_state);
        Sphere2.SetActive(!_state);
    }

    public /* override*/ void Activate(int state)
    {
        Activate(state != 0);
    }

    void Start () {
        Activate(false);
	}
	
	
	void Update () {
        // misc area for more detailed activation mechanics 
	}
}