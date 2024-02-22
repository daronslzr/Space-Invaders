using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public Rigidbody2D rb;
    public PolygonCollider2D polygonCollider;

    //Variables used for movement
    public float dirX;
    public float movementVelocity = 7f;

    public GameObject laserAttackPrefab;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (GameManager.Instance.gameState == GameState.Playing)
        {
            //Gets the magnitude of motion in the x-axis.
            dirX = Input.GetAxisRaw("Horizontal");
            //Moves the player in the x-axis
            rb.velocity = new Vector2(dirX * movementVelocity, rb.velocity.y);
            //Shoots laser when d or up arrow is pressed
            if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            {
                GameObject laserAttack = Instantiate(laserAttackPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
