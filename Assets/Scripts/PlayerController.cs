using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    private const float movespeed = 5f;

	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;

        transform.position += new Vector3(x, y);
    }
}
