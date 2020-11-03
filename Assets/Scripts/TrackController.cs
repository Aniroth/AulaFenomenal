using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    public GameObject[] tiles;

    GameObject newTile;
    int lastTile;

    void Start()
    {
        lastTile = Random.Range(0, tiles.Length);
        newTile = Instantiate(tiles[lastTile], transform);
    }

    void Update()
    {
        if (newTile.transform.position.z <= 81.2f)
        {
            int newTileIndex = Random.Range(0, tiles.Length);

            while (newTileIndex == lastTile)
            {
                newTileIndex = Random.Range(0, tiles.Length);
            }

            newTile = Instantiate(tiles[newTileIndex], transform);
            lastTile = newTileIndex;
        }
    }
}
