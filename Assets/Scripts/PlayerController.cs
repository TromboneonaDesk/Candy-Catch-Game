using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] int movementSpeed;
    int moveDirection = 0;
    int score;
    int scoreMulti;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        transform.position += new Vector3(moveDirection * movementSpeed * dt,0);
    }
    public void left(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            moveDirection -= 1;
        }
        else if (context.canceled)
        {
            moveDirection += 1;
        }
    }
    public void right(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            moveDirection += 1;
        }
        else if (context.canceled)
        {
            moveDirection -= 1;
        }
    }



    public void SetSpeed(int speed)
    {
        this.movementSpeed = speed; 
    }

    public void SetMulti(int mutli)
    {
        this.scoreMulti = mutli;
    }
    public void SetScore(int score)
    { this.score = score; }

    public int GetScore()
    { return score; }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Candy")
        {
            score += col.gameObject.GetComponent<Candy>().GetWorth() * scoreMulti;
            GameObject.Destroy(col.gameObject);
        }
      
    }


}
