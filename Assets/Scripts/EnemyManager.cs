using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    public System.Random random = new System.Random();
    //Object components
    public PolygonCollider2D polygonCollider;
    //Enemy speed
    public float speed = 3f;
    //Position in y
    public float dirY;
    //Positions in y
    public int[] yPositionsArray = new int[] { -1, 0, 1, 2, 3, 4 };
    public float[] xPositionsArray = new float[] { -6.25f, 6.25f};
    //index for arrays
    int yIndex;
    int xIndex;
    //Attack prefab
    public GameObject enemyAttackPrefab;
    //Time variables
    public float time = 0f;
    public float seconds;
    bool shoot = false;

    void Start()
    {
        yIndex = random.Next(yPositionsArray.Length);
        xIndex = random.Next(xPositionsArray.Length);
        transform.position = new Vector2(xPositionsArray[xIndex], yPositionsArray[yIndex]);
    }

    void Awake()
    {
        Instance = this; 
    }

    void Update()
    {
        EnemyTimer();
        ShootAttack();
        if (xPositionsArray[xIndex] == -6.25)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x > 6.25f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < -6.25f)
            {
                Destroy(gameObject);
            }
        }
    }

    void EnemyTimer()
    {
        time += Time.deltaTime;
        seconds = Mathf.FloorToInt(time % 60);
    }

    void ShootAttack()
    {
        if (seconds == 1 && shoot ==false)
        {
            GameObject enemyAttack = Instantiate(enemyAttackPrefab);
            shoot = true;
        }
    }
}
