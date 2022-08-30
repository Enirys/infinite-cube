using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float tileLength = 35f;
    private float spawnZ = 8f;
    private int lastPrefabIndex = 0;

	// Use this for initialization
	void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < 4; i++)
        {
            if(i < 2)
            {
                SpawnTile(0);
            }
            else
                SpawnTile();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(playerTransform.position.z > (spawnZ - 4 * tileLength))
        {
            SpawnTile();
        }
	}

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }

    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
