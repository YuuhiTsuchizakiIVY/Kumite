using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPortion_Controller : MonoBehaviour
{
    GameDirector G_Director;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        G_Director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        rb = GetComponent<Rigidbody2D>();
        this.rb.velocity = new Vector2(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("É|Å[ÉVÉáÉìêGÇÍÇΩ");
            G_Director.nowPortionNum++;
            Destroy(this.gameObject);
        }
    }
}
