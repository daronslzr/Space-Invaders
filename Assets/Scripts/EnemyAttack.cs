using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static EnemyAttack Instance {  get; private set; }
    float positionX;
    float positionY;
    float yDistance = 0.5f;
    float speed = 2.5f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Its starting position will be defined by the enemy's position
        positionX = EnemyManager.Instance.transform.position.x;
        positionY = EnemyManager.Instance.transform.position.y;
        transform.position = new Vector2(positionX, positionY - yDistance);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -5.25 || GameManager.Instance.gameState == GameState.Ended)
        {
            Destroy(gameObject);
        }
    }
}
