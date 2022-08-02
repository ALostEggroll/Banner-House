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
    // Bounds of the spawner
    public float xRange = 1f;
    public float yRange = 1f;
    public float zRange = 1f;
    void Start()
    {
        location = transform.position;
        Debug.Log("location is at" + location);
    }
    public void SetTeam(List<GameObject> units)
    {
        this.units = units;
    }
    public void SpawnTeam(List<GameObject> units)
    {
        foreach(GameObject unit in units)
        {
            SpawnRandomPoint(unit); 
        }
    }
    public void SpawnRandomPoint(GameObject unit)
    {
        float xOffset = Random.Range(0, xRange);
        float yOffset = Random.Range(0, yRange);
        float zOffset = Random.Range(0, zRange);
        Vector3 randomPoint = new Vector3(xOffset, yOffset, zOffset);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            Debug.Log("Unit " + unit.name + " spawned at " + hit.position);
            Instantiate(unit, randomPoint, Quaternion.identity);
            Debug.Log("But ended up at " + unit.transform.position);
            //unit.GetComponent<UnitController>().WarpTo(hit.position);
            //Debug.Log("So I forced it to go to " + unit.transform.position);
            //unit.transform.position = randomPoint;
        }
    }
}
