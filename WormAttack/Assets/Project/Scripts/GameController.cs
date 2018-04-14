using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject boxPrefab;
    public int tileSize = 32;
    public float boxChance = 0.1f;

	// Use this for initialization
	void Start () {
        for (int y = Screen.height / 2 - tileSize; y > -Screen.height / 2 + 2 * tileSize; y -= tileSize)
        {
            for (int x = Screen.width / 2 - tileSize; x > -Screen.width / 2 + tileSize; x -= tileSize)
            {
                if (Random.value < boxChance)
                {
                    GameObject boxInstance = Instantiate(boxPrefab);
                    boxInstance.transform.SetParent(transform.parent);
                    boxInstance.transform.position = new Vector2(
                        (x - tileSize / 2) / 100f,
                        (y - tileSize / 2) / 100f
                    );
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
