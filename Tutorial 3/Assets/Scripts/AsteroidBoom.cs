﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidBoom : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
 
    private GameController gameController;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot Find 'GameController' script");
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player")
        {
            GameObject GameController = GameObject.Find("GameController");
            GameController gameScript = GameController.GetComponent<GameController>();
            if (gameScript.lives > 1)
            {
                gameScript.lives = gameScript.lives - 1;
                gameScript.SetLivesText();

            }
           else if (gameScript.lives <= 1)
            {
                gameScript.lives = gameScript.lives - 1;
                gameScript.SetLivesText();
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
                Destroy(other.gameObject);
               
            }
        }
       
        Destroy(gameObject);
       
        gameController.AddScore(scoreValue);

    }
}
