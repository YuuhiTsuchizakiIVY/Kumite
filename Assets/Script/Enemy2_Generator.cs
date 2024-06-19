using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Generator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float Span = 3.0f;
    float delta = 0;
    float NowTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        delta += Time.deltaTime;
        NowTime += Time.deltaTime;
        if(NowTime < 20)
        {
            Span = 8.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else if (NowTime < 30)
        {
            Span = 5.0f;
            if (delta > Span)

            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else if (NowTime < 50)
        {
            Span = 4.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
        else
        {
            Span = 3.0f;
            if (delta > Span)
            {
                delta = 0;
                EnemyGanerate();
            }
        }
    }

    public void EnemyGanerate()
    {
        GameObject Orb = Instantiate(EnemyPrefab);
        Orb.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
