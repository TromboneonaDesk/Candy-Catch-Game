using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Candy : MonoBehaviour
{

    [SerializeField] Sprite[] spriteOptions;
    [SerializeField] int[] candyScore;
    [SerializeField] int[] candyRarity;
    SpriteRenderer spriteRenderer;
    [SerializeField] int fallingSpeed;
    int currentCandy;
    int totalChance;
    public int worth;

  


    int calculateChance()//CALCULATES THE CHANCES
    {
        

        int x = Random.Range(0, totalChance);
        if ((x -= candyRarity[0]) < 0) // Test for A
        {
            return 0;
        }
        else if ((x -= candyRarity[1]) < 0) // Test for B
        {
            return 1;
        }
        else if ((x -= candyRarity[2]) < 0) // Test for C
        {
            return 2;
        }
        else if ((x -= candyRarity[3]) < 0) // Test for D
        {
            return 3;
        }
        else if ((x -= candyRarity[4]) < 0) // Test for E
        {
            return 4;
        }
        else // No need for final if statement
        {
            return 5;
        }
       
    }

    void Start()
    {
        foreach (int c in candyScore)
            totalChance += c;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentCandy = calculateChance();
        spriteRenderer.sprite = spriteOptions[currentCandy];
        worth = candyScore[currentCandy]; //SET THE WORTH.
    }

    public int GetWorth()
    {
        return worth;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        
        transform.position -= new Vector3(0, fallingSpeed * dt);
        if (transform.position.y < -5f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
