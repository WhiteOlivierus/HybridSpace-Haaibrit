using UnityEngine;

public class Gaze : MonoBehaviour
{
    public GameObject gazeTimerIndicator;
    public float gazeTimerIndicatorSize;

    private GameObject lastHit;
    private bool gazing = false;
    private float gazeTimer = 0f;
    private float baseGazeTimerIndicatorSize;

    void Start()
    {
        baseGazeTimerIndicatorSize = gazeTimerIndicator.transform.localScale.x;
    }

    void Update()
    {
        int layerMask = 1 << 9;

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
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
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);
                // Debug.Log("Did Hit");
                if (gazeTimer >= 2f)
                {
                    lastHit.GetComponent<IGazeInterface>().GazeMethod();
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

            float x = gazeTimerIndicator.transform.localScale.x + (baseGazeTimerIndicatorSize * gazeTimer);
            float y = gazeTimerIndicator.transform.localScale.y + (baseGazeTimerIndicatorSize * gazeTimer);
            // gazeTimerIndicator.GetComponent<Material>().renderQueue = qeue;

            print(string.Format("{0} :{1}", x, y));

            Vector3 gazeTimerIndicatorScale = new Vector3(Mathf.Clamp(x, baseGazeTimerIndicatorSize, gazeTimerIndicatorSize),
                                                        Mathf.Clamp(y, baseGazeTimerIndicatorSize, gazeTimerIndicatorSize),
                                                        gazeTimerIndicator.transform.localScale.z);

            print(gazeTimerIndicatorScale);

            if (gazeTimerIndicator)
                gazeTimerIndicator.transform.localScale = gazeTimerIndicatorScale;

        }
        else
        {
            gazeTimer = 0f;

            if (gazeTimerIndicator)
                gazeTimerIndicator.transform.localScale = new Vector3(baseGazeTimerIndicatorSize, baseGazeTimerIndicatorSize, gazeTimerIndicator.transform.localScale.z);
        }
    }
}

