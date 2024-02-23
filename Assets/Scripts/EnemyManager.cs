using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
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
    public float[] xPositionsArray = new float[] { -6.25f, 6.25f };
    //index for arrays
    int yIndex;
    int xIndex;
    //Attack prefab
    public GameObject enemyAttackPrefab;
    //Time variables
    public float time = 0f;
    public float seconds;
    bool shoot = false;
    //Attack values?
    public int[] xAttackPositions = Enumerable.Range(-5, 11).ToArray();
    public int attackIndex1;
    //public int attackIndex2;


    void Start()
    {
        //Sets the enemy to a random position
        yIndex = random.Next(yPositionsArray.Length);
        xIndex = random.Next(xPositionsArray.Length);
        transform.position = new Vector2(xPositionsArray[xIndex], yPositionsArray[yIndex]);
        //Sets the attacks to random positions
        attackIndex1 = xAttackPositions[random.Next(xAttackPositions.Length)];
        /*xAttackPositions = xAttackPositions.Where(val => val != attackIndex1).ToArray();
        attackIndex2 = xAttackPositions[random.Next(xAttackPositions.Length)];*/
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        /*
        EnemyTimer();
        ShootAttack();
        */
        
        //The enemy will move to the right or left depending its value on x
        if (xPositionsArray[xIndex] == -6.25)
        {
            ShootAttackRight();
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > 6.25f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            ShootAttackLeft();
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
        if (seconds == 1 && shoot == false)
        {
            GameObject enemyAttack = Instantiate(enemyAttackPrefab);
            shoot = true;
        }
    }

    //Instantiates the prefab based off the enemy's movement direction 
    void ShootAttackRight()
    {
        if ((transform.position.x >= attackIndex1) && shoot == false)
        {
            GameObject enemyAttack = Instantiate(enemyAttackPrefab, transform.position, Quaternion.identity);
            shoot = true;
        }
    }

    void ShootAttackLeft()
    {
        if ((transform.position.x <= attackIndex1) && shoot == false)
        {
            GameObject enemyAttack = Instantiate(enemyAttackPrefab, transform.position, Quaternion.identity);
            shoot = true;
        }
    }
}
