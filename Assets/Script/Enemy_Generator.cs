using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float Span = 3.0f;
    float Delta = 0;
    float NowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Delta += Time.deltaTime;
        this.NowTime += Time.deltaTime;
        if (this.NowTime < 20)
        {
            Span = 5.0f;
            if (this.Delta > this.Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
        else if (this.NowTime < 30)
        {
            Span = 4.0f;
            if (this.Delta > this.Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
        else if (this.NowTime < 50)
        {
            Span = 3.0f;
            if (this.Delta > this.Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
        else
        {
            Span = 1.5f;
            if (this.Delta > this.Span)
            {
                this.Delta = 0;
                EnemyGenerate();
            }
        }
    }

    public void EnemyGenerate()
    {
        GameObject Enemy = Instantiate(EnemyPrefab);
        Enemy.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
    }
}
