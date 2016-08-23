using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class PlayerController : NetworkBehaviour {

    private Console console;
    private const float movespeed = 3f;
    public GameObject bullet;

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void Start () {
        console = null;
    }

    void Update () {

        if (!isLocalPlayer)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            console = CheckConsole();

        if (console != null)
            return;

        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * movespeed;
        var y = Input.GetAxisRaw("Vertical") * Time.deltaTime * movespeed;

        transform.position += new Vector3(x, y);
    }

    public Console CheckConsole () {
        if (console != null) {
            console.closeConsole();
            return null;
        }
        
        foreach (Collider2D c in Physics2D.OverlapCircleAll(transform.position, 2f)) {
            if (c.gameObject.tag == "Console") {
                Console temp = c.gameObject.GetComponent<Console>();
                temp.openConsole();
                return temp;
            }
        }
        return null;
    }
}
