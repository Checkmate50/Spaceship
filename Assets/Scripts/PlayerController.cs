using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    private const float movespeed = 3f;
    public Bullet bullet;

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void Update () {

        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
            NetworkServer.Spawn(temp);
        }

        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movespeed;
        var y = Input.GetAxisRaw("Vertical") * Time.deltaTime * movespeed;

        transform.position += new Vector3(x, y);
    }
}
