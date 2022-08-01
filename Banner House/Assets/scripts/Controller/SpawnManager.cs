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
    public Vector3 location;   // Location of the spawner
    public float xRange = 1f;
    public float yRange = 1f;
    public float zRange = 1f;
    void Start()
    {
        location = transform.position;
    }
    public void SpawnTeam(List<GameObject> units)
    {
        foreach(GameObject unit in units)
        {
            SpawnRandomPoint(unit.transform); 
        }
    }
    public void SpawnRandomPoint(Transform unit)
    {
        float xOffset = Random.Range(0, xRange);
        float yOffset = Random.Range(0, yRange);
        float zOffset = Random.Range(0, zRange);
        Vector3 randomPoint = new Vector3(xOffset, yOffset, zOffset);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            unit.transform.position = randomPoint;
        }
    }
}
