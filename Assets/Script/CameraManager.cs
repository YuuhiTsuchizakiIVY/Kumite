using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private HeroKnight _Player;
    private Vector3 _InitPosition;

    // Start is called before the first frame update
    void Start()
    {
        _Player = FindObjectOfType<HeroKnight>();
        _InitPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()
    {
        float y = _Player.transform.position.y;
        float x = _Player.transform.position.x;

        transform.position = new Vector3(x, y+2, transform.position.z);
    }
}
