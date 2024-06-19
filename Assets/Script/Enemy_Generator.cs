using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float Span;
    float Delta;
    float NowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Delta += Time.deltaTime;
        NowTime += Time.deltaTime;
        if (NowTime < 20)
        {
            Span = 5.0f;
            if (Delta > Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
        else if (NowTime < 30)
        {
            Span = 6.0f;
            if (Delta > Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
        else if (NowTime < 50)
        {
            Span = 5.0f;
            if (Delta > Span)
            {
                Delta = 0;
                EnemyGenerate();
            }
        }
        else
        {
            Span = 3.0f;
            if (Delta > Span)
            {
                Delta = 0;
                EnemyGenerate();
            }
        }
    }

    public void EnemyGenerate()
    {
        GameObject Enemy = Instantiate(EnemyPrefab);
        Enemy.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
