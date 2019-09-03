using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public float delay;

    void Update()
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject, delay);
    }
}
