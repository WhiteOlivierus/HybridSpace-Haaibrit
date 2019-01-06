using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
// The script must be linked to the main camera
public class HeadTracking : MonoBehaviour
{
    // The initials orientation
    private int initialOrientationX;
    private int initialOrientationY;
    private int initialOrientationZ;

    // Initialization	
    void Start()
    {
        // Activate the gyroscope
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;

        // Save the firsts values
        initialOrientationX = (int)Input.gyro.rotationRateUnbiased.x;
        initialOrientationY = (int)Input.gyro.rotationRateUnbiased.y;
        initialOrientationZ = (int)-Input.gyro.rotationRateUnbiased.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(initialOrientationX - Input.gyro.rotationRateUnbiased.x, initialOrientationY - Input.gyro.rotationRateUnbiased.y, initialOrientationZ + Input.gyro.rotationRateUnbiased.z);
    }
}