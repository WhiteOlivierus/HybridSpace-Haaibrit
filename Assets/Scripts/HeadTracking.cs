using UnityEngine;
using System.Collections;

public class HeadTracking : MonoBehaviour
{
    private int initialOrientationX;
    private int initialOrientationY;
    private int initialOrientationZ;

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
        transform.Rotate(initialOrientationX - Input.gyro.rotationRateUnbiased.x, initialOrientationY - Input.gyro.rotationRateUnbiased.y, initialOrientationZ + Input.gyro.rotationRateUnbiased.z);
    }
}