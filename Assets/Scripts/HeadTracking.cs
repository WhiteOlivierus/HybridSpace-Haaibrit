using UnityEngine;
using System.Collections;

public class HeadTracking : MonoBehaviour
{
    private int initialOrientationX;
    private int initialOrientationY;
    private int initialOrientationZ;

    public bool x;
    public bool y;
    public bool z;

    void Start()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;

        initialOrientationX = (int)Input.gyro.rotationRateUnbiased.x;
        initialOrientationY = (int)Input.gyro.rotationRateUnbiased.y;
        initialOrientationZ = (int)-Input.gyro.rotationRateUnbiased.z;
    }

    void Update()
    {
        transform.Rotate(x ? initialOrientationX - Input.gyro.rotationRateUnbiased.x : 0f,
                        y ? initialOrientationY - Input.gyro.rotationRateUnbiased.y : 0f,
                        z ? initialOrientationZ + Input.gyro.rotationRateUnbiased.z : 0f);
    }
}