using UnityEngine;

public class Colors : MonoBehaviour
{
    public Color white;
    public Color red;
    public Color orange;
    public Color yellow;
    public Color green;
    public Color blue;
    public Color purple;

    [Space]

    public Color platformRed;
    public Color platformOrange;
    public Color platformYellow;
    public Color platformGreen;
    public Color platformBlue;
    public Color platformPurple;

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
