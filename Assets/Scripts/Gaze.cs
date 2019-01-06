using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    public SpriteRenderer gazeTimerIndicator;

    private GameObject lastHit;
    private bool gazing = false;
    private float gazeTimer = 0f;

    void Update()
    {
        int layerMask = 1 << 9;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(transform.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (lastHit != null)
            {
                lastHit.gameObject.GetComponent<Renderer>().material.color = Color.white;
                lastHit = null;
            }

            lastHit = hit.collider.gameObject;

            if (lastHit.tag == "gazeable")
            {
                gazing = true;
                Debug.DrawRay(transform.position, transform.TransformDirection(transform.forward) * hit.distance, Color.blue);
                Debug.Log("Did Hit");
                if (gazeTimer >= 2f)
                {
                    lastHit.GetComponent<IGazeInterface>().GazeMethod();
                    // lastHit.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        else
        {
            gazing = false;
            if (lastHit != null)
            {
                lastHit.gameObject.GetComponent<Renderer>().material.color = Color.white;
                lastHit = null;
            }
        }
    }

    void FixedUpdate()
    {
        if (gazing)
        {
            gazeTimer += 2f / 60f;
            gazeTimerIndicator.color = new Color(gazeTimerIndicator.color.r,
                                                gazeTimerIndicator.color.g,
                                                gazeTimerIndicator.color.b,
                                                gazeTimer / 2f
                                                );
        }
        else
        {
            gazeTimer = 0f;
            gazeTimerIndicator.color = new Color(gazeTimerIndicator.color.r,
                                    gazeTimerIndicator.color.g,
                                    gazeTimerIndicator.color.b,
                                    0f
                                    );
        }
    }
}

