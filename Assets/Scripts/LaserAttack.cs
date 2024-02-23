using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaserAttack : MonoBehaviour
{
    public static LaserAttack Instance { get; private set; }
    float positionX;
    //The starting position in the y-axis is fixed
    float positionY = -3.6f;
    float speed = 2.5f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        positionX = PlayerManager.Instance.rb.position.x;
        transform.position = new Vector2 (positionX, positionY);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if(transform.position.y > 5.25 || GameManager.Instance.gameState == GameState.Ended)
        {
            Destroy(gameObject);
        }
    }
}
