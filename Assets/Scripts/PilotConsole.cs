using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PilotConsole : Console {

    [SerializeField]
    private Image enemy;
    private List<Image> enemyImages;

    protected override void CloseUI() {
        foreach (Image i in enemyImages)
            Destroy(i.gameObject);
        enemyImages = new List<Image>();
    }

    protected override void OpenUI() {
        Image newEnemy = Instantiate<Image>(enemy);
        enemyImages.Add(newEnemy);
        RectTransform rect = newEnemy.GetComponent<RectTransform>();
        rect.SetParent(canvas, false);
        rect.localPosition = new Vector3(0f, 0f);
    }

    // Use this for initialization
    void Start () {
        enemyImages = new List<Image>();
	}
	
	// Update is called once per frame
	void Update () {

    }
}
