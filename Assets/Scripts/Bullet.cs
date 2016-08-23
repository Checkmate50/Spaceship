using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int speed = 5;

	void Update ()
    {
        transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
	}
}
