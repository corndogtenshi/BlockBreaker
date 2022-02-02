using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour
{

    //public Text debugBrickCount;
    public GameObject smoke;
    public AudioClip crack;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;
    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
            print(breakableCount);
            
        }
        timesHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        //debugBrickCount.text = "BreakableCount: " + breakableCount;
    }

    void OnCollisionEnter2D()
    {
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
            if (GameObject.FindObjectOfType<Ball>().hasStarted == true)
            {
                if (Brick.breakableCount <= 0)
                {
                    Debug.Log("Loading next level due to all bricks being broken.");
                    levelManager.LoadNextLevel();

                }
            }
        }

    }
    void HandleHits()
    {

        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            Debug.Log("breakableCount: " + breakableCount);
            //debugBrickCount.text = "BreakableCount: " + breakableCount;
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {  
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing!");
        }
    }
    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule smokeColor = smokePuff.GetComponent<ParticleSystem>().main;
        smokeColor.startColor = this.GetComponent<SpriteRenderer>().color;
    }
    

}


