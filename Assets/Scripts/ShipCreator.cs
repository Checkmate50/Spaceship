using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ShipCreator : NetworkBehaviour {

    [SerializeField]
    private GameObject box;
    [SerializeField]
    private GameObject pilotConsole;

    // Use this for initialization
    public override void OnStartServer () {

        CmdCreateWalls();
        CmdCreateConsoles();

        Destroy(gameObject);
    }

    [Command]
    private void CmdCreateWalls() {
        GameObject toSpawn;

        for (int i = 0; i < 16; i++) {
            toSpawn = (GameObject)Instantiate(box, new Vector3(-7.5f + i, 5), Quaternion.identity);
            NetworkServer.Spawn(toSpawn);
            toSpawn = (GameObject)Instantiate(box, new Vector3(-7.5f + i, -5), Quaternion.identity);
            NetworkServer.Spawn(toSpawn);
        }
        for (int i = 0; i < 11; i++) {
            toSpawn = (GameObject)Instantiate(box, new Vector3(-8.5f, -5f + i), Quaternion.identity);
            NetworkServer.Spawn(toSpawn);
            toSpawn = (GameObject)Instantiate(box, new Vector3(8.5f, -5f + i), Quaternion.identity);
            NetworkServer.Spawn(toSpawn);
        }
    }

    [Command]
    private void CmdCreateConsoles() {
        GameObject toSpawn;

        toSpawn = (GameObject)Instantiate(pilotConsole, new Vector3(0, 3f), Quaternion.identity);
        NetworkServer.Spawn(toSpawn);
    }
}
