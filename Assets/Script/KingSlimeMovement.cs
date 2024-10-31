using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeMovement : ObjectMovementController
{
    [SerializeField] private ObjectVisionController vision;


    private Vector3 direction = Vector3.zero;

    [SerializeField] private float timeForNextJump;

    private float timeRun;

    private bool isInAir = false;
    public bool IsAir { get { return isInAir; }}


    [SerializeField] private float minDistance;

    [SerializeField] private float gravity;

    [SerializeField] private KingSlimeAttack kingSlimeAttack;

    private float distanceMove;

    private Vector3 lastPosition;

    private Vector3 earthSurface;
    // Start is called before the first frame update

 
    new void Start()
    {
        base.Start();

        timeRun = Time.time;

        
    }


    public Collider2D GetPlayer() {
        return vision.GetEnemy();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dirt") {

            isInAir = false;

            timeRun = Time.time;

            earthSurface = transform.position;

            this.direction = Vector3.zero;

        }
    }

    public float GetVelocityY(Collider2D player, float initialVelocityX, float distanceToPlayer){

        float fixedGravity = gravity * 0.02f * 0.02f;

        float velocityY = fixedGravity * distanceToPlayer / (2 * Mathf.Abs(initialVelocityX));

        Debug.Log("check velocity Y : " + velocityY);

    

        return velocityY;
    }

    private void FollowStraightJump() { 

        this.direction.y = this.jumpForce * Time.fixedDeltaTime;

        Debug.Log("jump straight");

        float defaultHeight = 4;

        distanceMove = defaultHeight;

    }

    private void FollowCurveJump(Collider2D player, float distanceToPlayer) {

        this.direction.x = Mathf.Sign(player.transform.position.x - transform.position.x);

        this.Flip(direction.x);

        this.direction.x *= Time.fixedDeltaTime * speedRun;

        this.direction.y = GetVelocityY(player, this.direction.x, distanceToPlayer);

        distanceMove = distanceToPlayer;

        Debug.Log("jump curve");
    }


    public override void Move()
    {
        Collider2D player = GetPlayer();


        if (player != null) {

            if (! isInAir && Time.time - timeRun > timeForNextJump) {

                float distanceToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);

                Debug.Log("check distance to player : " + distanceToPlayer);

                if (distanceToPlayer <= minDistance)
                {
                    FollowStraightJump();
                }
                else {

                   FollowCurveJump(player, distanceToPlayer);

                }

                isInAir = true;

                lastPosition = transform.position;

                kingSlimeAttack.IsAttackingEnemy = true;
            }   

        }


        transform.position += direction;

    }
}
