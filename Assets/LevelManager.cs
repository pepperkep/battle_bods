using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> enemies;
    public GameObject nextButton;
    private bool hasWon;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(false);
        }
        this.nextButton.SetActive(false);
    }

    public void StartEnemyPhase()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(enemies.Count == 0)
            hasWon = true;
        else
        {
            bool allNull = true;
            for(int i = 0; i < enemies.Count; i++)
            {
                if(enemies[i] != null)
                    allNull = false;
            }
            hasWon = allNull;
        }
        if(hasWon)
            this.nextButton.SetActive(true);
    }
}
