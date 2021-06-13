using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> enemies;
    private bool hasWon;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(false);
        }
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
        
    }
}
