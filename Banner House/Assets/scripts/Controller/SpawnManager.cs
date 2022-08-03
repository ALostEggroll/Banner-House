using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 *  Spawns units around a location set by a gameobject
 *  Uses Navmesh
 */
public class SpawnManager : MonoBehaviour
{
    public List<GameObject> units;  // Characters to be spawned
    public Vector3 location;        // Location of the spawner
    public Team team;
    // Bounds of the spawner
    public float xRange;
    public float yRange;
    public float zRange;
    void Start()
    {
        location = transform.position;
        Debug.Log(name + "'s location is at" + location);
        CombatManager.Instance.AddSpawner(this);
    }
    public void SetUnits(List<GameObject> units)
    {
        this.units = units;
    }
    public void SpawnUnits(List<GameObject> units)
    {
        foreach(GameObject unit in units)
        {
            SpawnRandomPoint(unit); 
        }
    }
    public void SpawnRandomPoint(GameObject unit)
    {
        float xOffset = Random.Range(location.x - xRange, location.x + xRange);
        float yOffset = Random.Range(location.y - yRange, location.y + yRange);
        float zOffset = Random.Range(location.z - zRange, location.z + zRange);
        Vector3 randomPoint = new Vector3(xOffset, yOffset, zOffset);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 50f, NavMesh.AllAreas))
        {
            Debug.Log("Unit " + unit.name + " spawned at " + hit.position);
            Instantiate(unit, randomPoint, Quaternion.identity);
            //SetTeam(unit);
            //unit.GetComponent<UnitController>().WarpTo(hit.position);
            //Debug.Log("So I forced it to go to " + unit.transform.position);
            //unit.transform.position = randomPoint;
        }
    }
    /*
    public void SetTeam(GameObject unit)
    {
        unit.GetComponent<UnitController>().SetTeam(team);
        unit.GetComponent<UnitController>().AddToCombatManager();
    }
    */
}
