using UnityEngine;

public class EatFood : MonoBehaviour, IGazeInterface
{
    public void GazeMethod()
    {
        Destroy(gameObject);
    }
}
