using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject food;
    public int amount;
    public float range;
    public int minutes;
    private List<GameObject> allFood = new List<GameObject>();

    private float timer;
    private bool notStartedYet = false;
    void fixedUpdate()
    {
        timer += Time.deltaTime;
        print(timer);
    }

    void Update()
    {
        if (allFood.Count <= 0)
        {
            for (int i = 0; i < amount; i++)
            {
                allFood.Add(Instantiate(food,
                                        transform.position + new Vector3(0f, 0f, Random.Range(range, -range)),
                                        Quaternion.identity));

                allFood[i].transform.SetParent(transform);
            }
        }
        else
        {
            foreach (GameObject g in allFood)
            {
                if (g == null)
                    allFood.Remove(g);

                if (allFood.Count <= 10 || timer >= 60 * (60 * minutes))
                {
                    if (!notStartedYet)
                    {
                        notStartedYet = true;
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, "Cage"));
                    }
                }
            }

        }



    }
}
