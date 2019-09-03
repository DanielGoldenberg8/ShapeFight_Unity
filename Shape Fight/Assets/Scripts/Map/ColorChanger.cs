using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Tilemaps;

public class ColorChanger : MonoBehaviour
{
    public Tilemap tilemap;

    public List<GameObject> platforms = new List<GameObject>();
    public List<Light2D> lights = new List<Light2D>();

    [Space]

    public Color chosenColor;

    public static ColorChanger instance;

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

        ChooseColor();
    }

    void Start()
    {
        SetColor();
    }
    
    void ChooseColor()
    {
        int num = Mathf.CeilToInt(Random.Range(0f, 6f));

        if (num == 1)
        {
            chosenColor = Colors.instance.platformRed;
        }
        if (num == 2)
        {
            chosenColor = Colors.instance.platformOrange;
        }
        if (num == 3)
        {
            chosenColor = Colors.instance.platformYellow;
        }
        if (num == 4)
        {
            chosenColor = Colors.instance.platformGreen;
        }
        if (num == 5)
        {
            chosenColor = Colors.instance.platformBlue;
        }
        if (num == 6)
        {
            chosenColor = Colors.instance.platformPurple;
        }
    }

    void SetColor()
    {
        tilemap.color = chosenColor;

        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<SpriteRenderer>().color = chosenColor;
        }

        foreach (Light2D light in lights)
        {
            light.color = chosenColor;
        }
    }
}
