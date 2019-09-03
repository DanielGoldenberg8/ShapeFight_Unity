using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorChanger : MonoBehaviour
{
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public GameObject platform4;
    public GameObject platform5;
    public GameObject platform6;
    public GameObject platform7;
    public GameObject platform8;
    public GameObject platform9;

    [Space]

    public Tile tile1;
    public Tile tile2;
    public Tile tile3;
    public Tile tile4;
    public Tile tile5;
    public Tile tile6;
    public Tile tile7;
    public Tile tile8;

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
    }

    void OnValidate()
    {
        ChooseColor();
        SetColor();
    }
    
    void ChooseColor()
    {
        int num = Mathf.FloorToInt(Random.Range(0f, 6f));

        if (num == 0)
        {
            chosenColor = Colors.instance.red;
        }
        if (num == 1)
        {
            chosenColor = Colors.instance.orange;
        }
        if (num == 2)
        {
            chosenColor = Colors.instance.yellow;
        }
        if (num == 3)
        {
            chosenColor = Colors.instance.green;
        }
        if (num == 4)
        {
            chosenColor = Colors.instance.blue;
        }
        if (num == 5)
        {
            chosenColor = Colors.instance.purple;
        }
    }

    void SetColor()
    {
        platform1.GetComponent<SpriteRenderer>().color = chosenColor;
        platform2.GetComponent<SpriteRenderer>().color = chosenColor;
        platform3.GetComponent<SpriteRenderer>().color = chosenColor;
        platform4.GetComponent<SpriteRenderer>().color = chosenColor;
        platform5.GetComponent<SpriteRenderer>().color = chosenColor;
        platform6.GetComponent<SpriteRenderer>().color = chosenColor;
        platform7.GetComponent<SpriteRenderer>().color = chosenColor;
        platform8.GetComponent<SpriteRenderer>().color = chosenColor;
        platform9.GetComponent<SpriteRenderer>().color = chosenColor;

        tile1.color = chosenColor;
        tile2.color = chosenColor;
        tile3.color = chosenColor;
        tile4.color = chosenColor;
        tile5.color = chosenColor;
        tile6.color = chosenColor;
        tile7.color = chosenColor;
        tile8.color = chosenColor;
    }
}
