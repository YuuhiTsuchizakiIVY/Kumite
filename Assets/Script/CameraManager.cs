using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private HeroKnight _player;
    private Vector3 _initPos;

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<HeroKnight>();
        _initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()
    {
        float y = _player.transform.position.y;
        float x = _player.transform.position.x;

        transform.position = new Vector3(x, y+2, transform.position.z);
    }
}
