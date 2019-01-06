using UnityEngine;

public class ColorChanger : MonoBehaviour, IGazeInterface
{
    public Color whatColor;

    public void GazeMethod()
    {
        gameObject.GetComponent<Renderer>().material.color = whatColor;
    }
}
