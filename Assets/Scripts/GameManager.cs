using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{



    int candiesLeft = 15;
    [SerializeField] GameObject prefab;
    [SerializeField] PlayerController player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI endMessage;
    [SerializeField] Button retryButton;
    [SerializeField] Button[] characters;
    [SerializeField] Sprite[] characterSprites;
    [SerializeField] int[] characterSpeeds;
    [SerializeField] int[] characterMultiplier;
    Candy[] candies = new Candy[15];
    int score;
    int character;
    // Start is called before the first frame update


    IEnumerator gameLoop()
    {
        player.SetScore(0);
        score = 0;
        endMessage.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        foreach (Button butt in characters)//incase we want to add more characters(we dont)
        {
            butt.gameObject.SetActive(false);
        }
        print("Game start!");
        GameObject candy = null;
        for (int i = 0; i < candiesLeft; i++)
        {
            print("spawned!");
            candy = GameObject.Instantiate(prefab) as GameObject;
            candy.transform.position = new Vector3(Random.Range(-10, 10), 12);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
        while (candy != null)
        {
            yield return new WaitForSeconds(0.05f);
        }
        print("Game over!");
        endMessage.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        if (score > 50)
        {
            endMessage.text = "Candy Craze";
        }
        else if (score > 35)
        {
            endMessage.text = "Halloween";
        }
        else if (score > 15)
        {
            endMessage.text = "Sugar rush";
        }
        else
        {
            endMessage.text = "Sadness";
        }
    }

    void setCharacter(int character)
    {
        this.character = character;
    }


    IEnumerator characterSelection()
    {
        character = -1;
        foreach (Button butt in characters)//incase we want to add more characters(we dont)
        {
            butt.gameObject.SetActive(true);
        }
        endMessage.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        while (character == -1)
        {
            yield return new WaitForSeconds(0.05f);
        }
        print(character);
    player.SetSpeed(characterSpeeds[character]);
    player.SetMulti(characterMultiplier[character]);
        player.GetComponent<SpriteRenderer>().sprite = characterSprites[character];
        StartCoroutine(gameLoop());
    }

    void startGame()
    {
        StartCoroutine(characterSelection());
    }


void Start()
    {


        /* THIS CODE DOES NOT WORK IT THINKS INDEX IS 2 >:/
         *   int index = 0;
        foreach (Button butt in characters)//incase we want to add more characters(we dont)
        {
            butt.onClick.AddListener(delegate { setCharacter(index); });
            index++;
        }
        */
        characters[0].onClick.AddListener(delegate { setCharacter(0); });
        characters[1].onClick.AddListener(delegate { setCharacter(1); });
        print("start");
        retryButton.onClick.AddListener(startGame);
        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        score = player.GetScore();
        scoreText.text = "Score: " + score;
    }
}
