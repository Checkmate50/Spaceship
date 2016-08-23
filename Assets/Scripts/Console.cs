using UnityEngine;
using System.Collections;

public abstract class Console : MonoBehaviour {

    private bool inUse;
    protected Transform canvas;

    protected virtual void Awake () {
        inUse = false;
        canvas = GameObject.Find("Canvas").transform;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected abstract void OpenUI ();

    protected abstract void CloseUI ();

    public void openConsole () {
        if (inUse)
            return;
        inUse = true;
        OpenUI();
    }

    public void closeConsole () {
        inUse = false;
        CloseUI();
    }
}
