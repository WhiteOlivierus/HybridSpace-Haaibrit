using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChicken : MonoBehaviour
{
    private float timer = 2f;
    private float newAngle;
    private float oldAngle;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            oldAngle = transform.rotation.y;
            newAngle = Random.Range(-3f, 3f);
            timer = 0f;
        }
        else if (timer >= Random.Range(1f, 2f))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * Random.Range(0.5f, 2f), ForceMode.Impulse);
        }
        else
        {
            transform.Rotate(0f, Mathf.Lerp(oldAngle, newAngle, timer / 2f), 0f);
        }
    }
}
