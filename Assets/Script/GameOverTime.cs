using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTime : MonoBehaviour
{
    public Text text;
    GameDirector _gameDirector;
    GameObject directorScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void timeText()
    {
        _gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        text.text = _gameDirector.timeEnd.ToString("f1");
    }
}
