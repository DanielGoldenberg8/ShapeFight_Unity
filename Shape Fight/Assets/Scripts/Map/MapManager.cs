using UnityEngine;

public class MapManager : MonoBehaviour
{
    private GameObject[] enemy;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        if (player.isDead == true)
        {
            foreach (GameObject x in enemy)
            {
                Destroy(x.gameObject);
            }
        }
    }
}
