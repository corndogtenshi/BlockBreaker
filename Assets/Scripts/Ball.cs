using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Ball : MonoBehaviour {
    public Rigidbody2D rb;
    private Paddle paddle;
    public bool hasStarted = false;
    private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector);
	}

    // Update is called once per frame
    void Update() {
        if (!hasStarted)
        {
            //Lock ball relative to paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0)) //Wait for a mouse press in order to launch ball.
            {
                float isNeg = Random.Range(-1,1);
                float LaunchDirection = Random.Range(0.6f, 2.5f);
                if (isNeg == 0)
                {
                    isNeg = Random.Range(-1, 1);
                }
                else if (isNeg < 0)
                {
                    LaunchDirection *= -1;
                }

                print("Mouse clicked, launching ball...");
                //this.transform.position += new Vector3(2f, 10f, 0); : Deprecated...
                GetComponent<Rigidbody2D>().velocity = new Vector2(LaunchDirection, 10f);
                print(LaunchDirection);
                hasStarted = true;
            }

        }
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (hasStarted)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
            rb.velocity += velocityTweak;
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }

    }
}
