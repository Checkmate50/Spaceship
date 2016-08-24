using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class PlayerController : NetworkBehaviour {

    private Console console;
    private const float movespeed = 3f;

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
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
            console.CloseConsole();
            CmdToggleConsoleUse(console.GetUseID());
            return null;
        }
        
        foreach (Collider2D c in Physics2D.OverlapCircleAll(transform.position, 1.3f)) {
            if (c.gameObject.tag == "Console") {
                Console temp = c.gameObject.GetComponent<Console>();
                if (temp.OpenConsole()) {
                    CmdToggleConsoleUse(temp.GetUseID());
                    return temp;
                }
                return null;
            }
        }
        return null;
    }

    [Command]
    private void CmdToggleConsoleUse(int id) {
        DataManager.Instance().ToggleUse(id);
    }
}
