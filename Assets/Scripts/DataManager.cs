using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour {

    List<Enemy> enemies;
    List<Projectile> projectiles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
