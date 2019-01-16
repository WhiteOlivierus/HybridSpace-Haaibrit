using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject food;
    public int amount;
    public float range;

    private List<GameObject> allFood = new List<GameObject>();

    void Update()
    {
        if (allFood.Count <= 0)
            for (int i = 0; i < amount; i++)
            {
                allFood.Add(Instantiate(food,
                                        transform.position + new Vector3(0f, 0f, Random.Range(range, -range)),
                                        Quaternion.identity));

                allFood[i].transform.SetParent(transform);
            }
    }
}
