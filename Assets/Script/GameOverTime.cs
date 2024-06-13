using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTime : MonoBehaviour
{
    public Text text;
    GameDirector GameDirector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeText()
    {
        GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        text.text = GameDirector.TimeEnd.ToString("f1");
    }
}
