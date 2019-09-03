using UnityEngine;

public class MessageText : MonoBehaviour
{
    void Update()
    {
        HideMessage();
    }

    void HideMessage()
    {
        Destroy(gameObject, 6f);
    }
}
