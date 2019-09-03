using UnityEngine;

public class Colors : MonoBehaviour
{
    public Color white;
    public Color blue;
    public Color red;
    public Color purple;
    public Color green;
    public Color orange;
    public Color yellow;

    public static Colors instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
