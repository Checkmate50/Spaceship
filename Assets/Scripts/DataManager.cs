using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class DataManager : NetworkBehaviour {

    private SyncListBool inUse = new SyncListBool();
    [SerializeField]
    private int consoleCount;
    List<Enemy> enemies;
    List<Projectile> projectiles;
    private static DataManager instance;

	void Awake () { 
        if (instance != null)
            Destroy(gameObject);
        instance = this;
	}

    public override void OnStartServer() {
        for (int i = 0; i < consoleCount; i++)
            inUse.Add(false);
    }

    void OnDestroy() {
        instance = null;
    }

    public static DataManager Instance() {
        return instance;
    }

    public void ToggleUse(int id) {
        inUse[id] = !inUse[id];
    }

    public bool IsInUse(int id) {
        return inUse[id];
    }

    public List<Vector2> getEnemylocations () {
        List<Vector2> locations = new List<Vector2>();
        foreach (Enemy e in enemies)
            locations.Add(e.getPosition());
        return locations;
    }

    public List<Vector2> getProjectilelocations() {
        List<Vector2> locations = new List<Vector2>();
        foreach (Projectile p in projectiles)
            locations.Add(p.getPosition());
        return locations;
    }
}
