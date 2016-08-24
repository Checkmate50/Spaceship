using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Console : NetworkBehaviour {

    protected Transform canvas;
    [SerializeField]
    private int useID;

    protected virtual void Awake () {
        canvas = GameObject.Find("Canvas").transform;
    }
	
	// Update is called once per frame
	void Update () {
    }

    protected virtual void OpenUI() { }
    protected virtual void CloseUI() { }
       
    public bool OpenConsole () {
        if (DataManager.Instance().IsInUse(useID))
            return false;
        OpenUI();
        return true;
    }

    public void CloseConsole () {
        CloseUI();
    }

    public int GetUseID() {
        return useID;
    }
}
