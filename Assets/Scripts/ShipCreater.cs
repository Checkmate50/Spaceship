using UnityEngine;
using System.Collections;

public class ShipCreater : MonoBehaviour {

    [SerializeField]
    private GameObject box;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < 16; i++) {
            Instantiate(box, new Vector3(-7.5f + i, 5), Quaternion.identity);
            Instantiate(box, new Vector3(-7.5f + i, -5), Quaternion.identity);
        }
        for (int i = 0; i < 11; i++) {
            Instantiate(box, new Vector3(-8.5f, -5f + i), Quaternion.identity);
            Instantiate(box, new Vector3(8.5f, -5f + i), Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
