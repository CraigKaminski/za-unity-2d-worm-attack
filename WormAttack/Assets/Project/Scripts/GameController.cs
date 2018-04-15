using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Player player;
    public GameObject boxPrefab;
    public int tileSize = 32;
    public float boxChance = 0.1f;
    public GameObject monsterPrefab;
    public int monsterSize = 5;

    private List<Monster> monsters;

	// Use this for initialization
	void Start () {
        monsters = new List<Monster>();

        for (int y = Screen.height / 2 - tileSize; y > -Screen.height / 2 + 2 * tileSize; y -= tileSize)
        {
            for (int x = Screen.width / 2 - tileSize; x > -Screen.width / 2 + tileSize; x -= tileSize)
            {
                if (Random.value < boxChance)
                {
                    GameObject boxInstance = Instantiate(boxPrefab);
                    boxInstance.transform.SetParent(transform);
                    boxInstance.transform.position = new Vector2(
                        (x - tileSize / 2) / 100f,
                        (y - tileSize / 2) / 100f
                    );
                }
            }
        }

        Monster previousMonster = null;
        for (int i = 0; i < monsterSize; i++)
        {
            GameObject monsterInstance = Instantiate(monsterPrefab);
            monsterInstance.transform.SetParent(transform);
            monsterInstance.transform.position = new Vector2(
                -i * (tileSize / 100f),
                (Screen.height / 2 - tileSize / 2) / 100f
            );

            if (previousMonster != null)
            {
                previousMonster.next = monsterInstance.GetComponent<Monster>();
            } else
            {
                monsters.Add(monsterInstance.GetComponent<Monster>());
            }

            previousMonster = monsterInstance.GetComponent<Monster>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            SceneManager.LoadScene("Game");
        }
	}
}
