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

	// Use this for initialization
	void Start () {
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

        GameObject monsterInstance = Instantiate(monsterPrefab);
        monsterInstance.transform.SetParent(transform);
        monsterInstance.transform.position = new Vector2(0, (Screen.height / 2 - tileSize / 2) / 100f);
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            SceneManager.LoadScene("Game");
        }
	}
}
