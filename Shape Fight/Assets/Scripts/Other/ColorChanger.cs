using UnityEngine;
using UnityEngine.Tilemaps;

public class ColorChanger : MonoBehaviour
{
    public Color red;
    public Color orange;
    public Color yellow;
    public Color green;
    public Color blue;
    public Color purple;
    public Color white;

    private Color chosenColor;

    [Space]

    public Tile tile1;
    public Tile tile2;
    public Tile tile3;
    public Tile tile4;
    public Tile tile5;
    public Tile tile6;
    public Tile tile7;
    public Tile tile8;

    void Start()
    {
        SetTiles();
    }

    void ChooseColor()
    {
        float num = Mathf.Round(Random.Range(0f, 70f));

        if (num >= 60)
        {
            chosenColor = red;
        }
        else if (num >= 50 && num < 60)
        {
            chosenColor = orange;
        }
        else if (num >= 40 && num < 50)
        {
            chosenColor = yellow;
        }
        else if (num >= 30 && num < 40)
        {
            chosenColor = green;
        }
        else if (num >= 20 && num < 30)
        {
            chosenColor = blue;
        }
        else if (num >= 10 && num < 20)
        {
            chosenColor = purple;
        }
        else if (num >= 0 && num < 10)
        {
            chosenColor = white;
        }
    }

    void SetTiles()
    {
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
