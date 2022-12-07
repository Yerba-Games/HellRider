using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance;
    [SerializeField] int round;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject[] spawns;
    public bool lastRoundEnded;
    public int enemisLeft;
    private float score;
    [SerializeField] UIManager uIManager;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemisLeft == 0)
        {
            round++;
            score++;
            uIManager.score = score;
            SpawnEnemis(round);
            
        }
        //if (round >= 10)
        //{
          //  lastRoundEnded = true;
        //}
    }

    public void SpawnEnemis(int round)
    {
        for (var x = 0; x < round; x++)
        {
            GameObject spawn = spawns[Random.Range(0, spawns.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawn.transform.position, Quaternion.identity);
            enemisLeft++;
        }
    }
} 
