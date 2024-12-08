using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalSpawner : MonoBehaviour
{
    public GameObject fireElementalPrefab;
    public GameObject iceElementalPrefab;
    public int numberOfElementals = 4;

    public Vector3[] positionArrayFire = new[] { new Vector3(331.0f, 35.0f, 414.2f), 
                                             new Vector3(298.0f, 45.0f, 419.0f), 
                                             new Vector3(305.4f, 40.0f, 468.6f), 
                                             new Vector3(339.3f, 35.0f, 460.2f)};

    public Vector3[] positionArrayIce = new[] { new Vector3(466.0f, 35f, 464f),
                                             new Vector3(498f, 40f, 458f),
                                             new Vector3(499f, 45f, 419f),
                                             new Vector3(464f, 35f, 412f)};

    // Start is called before the first frame update
    void Start()
    {
        SpawnFireElementals();
        SpawnIceElementals();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.needtoSpawnElementals == true)
        {
            SpawnFireElementals();
            SpawnIceElementals();
            GameManager.Instance.needtoSpawnElementals = false;
        }
    }

    void SpawnFireElementals()
    {
        for (int i = 0; i < positionArrayFire.Length; i++)
        {
            Vector3 firePosition = positionArrayFire[i];
            Instantiate(fireElementalPrefab, firePosition, fireElementalPrefab.transform.rotation);
        }
    }
    void SpawnIceElementals()
    {
        for (int i = 0; i < positionArrayIce.Length; i++)
        {
            Vector3 icePosition = positionArrayIce[i];
            Instantiate(iceElementalPrefab, icePosition, iceElementalPrefab.transform.rotation);
        }
    }
}
