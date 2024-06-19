using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_Controller : MonoBehaviour
{
    GameDirector GameDirector;
    private Rigidbody2D RigitBody;
    // Start is called before the first frame update
    void Start()
    {
        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        RigitBody = GetComponent<Rigidbody2D>();
        RigitBody.velocity = new Vector2(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameDirector.Plus_Exp();
            Destroy(gameObject);
        }
    }
}
