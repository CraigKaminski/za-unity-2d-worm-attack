using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public float speed = 2f;
    public float horizntalLimit = 2.8f;
    public int tileSize = 32;

    private float movingDirection = 1f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * movingDirection, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (movingDirection > 0 && transform.position.x > horizntalLimit)
        {
            movingDirection *= -1;
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y - tileSize / 100f
            );
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * movingDirection, 0);
        } else if (movingDirection < 0 && transform.position.x < -horizntalLimit)
        {
            movingDirection *= -1;
            transform.position = new Vector2(
                transform.position.x,
                transform.position.y - tileSize / 100f
            );
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed * movingDirection, 0);
        }
    }
}
