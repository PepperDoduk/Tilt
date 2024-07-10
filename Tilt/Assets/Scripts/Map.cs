using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] Maps;
    public GameObject m;
    public Transform player;
    public PrefabMap[] Pm;

    public float inst;
    float lastSpawnY;

    private List<GameObject> spawnedMaps = new List<GameObject>();

    void Start()
    {
        if (Maps == null || Maps.Length == 0)
        {
            Debug.LogError("Maps array is not initialized or empty");
            return;
        }

        if (Pm == null || Pm.Length == 0)
        {
            Debug.LogError("Pm array is not initialized or empty");
            return;
        }

        inst = 0;
        lastSpawnY = player.position.y;
    }

    void Update()
    {
        if (spawnedMaps.Count == 0 || Mathf.Abs(player.position.y - lastSpawnY) > 5f)
        {
            if ((int)inst < 0 || (int)inst >= Maps.Length)
            {
                Debug.LogError("inst is out of bounds for Maps array");
                return;
            }

            Vector3 spawnPosition;
            if (spawnedMaps.Count == 0)
            {
                spawnPosition = new Vector3(0, player.position.y - 11.7f, 0);
            }
            else
            {
                GameObject lastMap = spawnedMaps[spawnedMaps.Count - 1];
                spawnPosition = new Vector3(0, lastMap.transform.position.y - 11.7f, 0);
            }

            GameObject newMap = Instantiate(Maps[(int)inst], spawnPosition, Quaternion.identity);
            newMap.transform.SetParent(m.transform);

            spawnedMaps.Add(newMap);

            lastSpawnY = newMap.transform.position.y;
            inst = Pm[(int)inst].ReturnRand(Pm.Length);

            if ((int)inst < 0 || (int)inst >= Pm.Length)
            {
                Debug.LogError("inst is out of bounds for Pm array");
                inst = 4;
            }
        }

        for (int i = spawnedMaps.Count - 1; i >= 0; i--)
        {
            if (Mathf.Abs(player.position.y - spawnedMaps[i].transform.position.y) > 40)
            {
                Destroy(spawnedMaps[i]);
                spawnedMaps.RemoveAt(i);
            }
        }
    }
}
