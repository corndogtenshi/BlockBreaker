using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;
    private float minX, maxX;
	// Use this for initialization
	void Start () {
        string curSprite = this.GetComponent<SpriteRenderer>().sprite.name;
        Debug.Log("curSprite: " + curSprite);

        if (curSprite == "traPaddle")
        {
            minX = 0.95f;
            maxX = 15.05f;
        }
        else
        {
            minX = 0.5f;
            maxX = 15.5f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
	}
    void MoveWithMouse()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
        this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, minX, maxX), transform.position.y, 0f);

    }
    void AutoPlay()
    {
        float ballPos = FindObjectOfType<Ball>().transform.position.x;
        this.transform.position = new Vector2((Mathf.Clamp(ballPos, minX, maxX)), this.transform.position.y); 
    }
}
