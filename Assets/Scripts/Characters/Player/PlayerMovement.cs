using UnityEngine;
using System.Collections;

namespace Platformer {
  public class PlayerMovement : MonoBehaviour {

    //Variables that correspond to certain components attached to object
    private Rigidbody2D rBody;
    private Animator anim;
    private Player_Manager PlayerManager;

    //tracks the players input
    public Vector2 movementVector;

    public float maxSpeed = 2.5f;

    public float jumpHeight;
    public bool isGrounded = false;

    // Use this for initialization
    void Start() {

      //jumpHeight;
      PlayerManager = GetComponent<Player_Manager>();
      rBody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();

      PlayerManager.currentMoveSpeed = PlayerManager.defaultMoveSpeed;
    }

    // Update is called once per frame
    void Update() {
      checkMovement();
      
      if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
        jump();
      }
    }

    /*
     * Fixed upate is better than update() for Rigidbodies. 
     * Applies the appropriate force to the rigidbody based on checkMovement() results
     * **/
    void FixedUpdate() {

      if (PlayerManager.canMove) {
        rBody.velocity = new Vector2(movementVector.x * PlayerManager.currentMoveSpeed, rBody.velocity.y);
      }
    }

    /*
     * Checks user input and calculates appropriate movement vector 
     * normalizing it between 0 and 1
     * */
    private void checkMovement() {
      if (PlayerManager.canMove) {
        movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        movementVector.Normalize();

        rBody.velocity = new Vector2(movementVector.x * PlayerManager.currentMoveSpeed, rBody.velocity.y);
      }
    }

    private void jump() {
      rBody.velocity = new Vector2(rBody.velocity.x, jumpHeight);
    }

    /*Three different collision events that control whether player
    *is considered grounded or not. Upon landing on ground first 
    * event happens, staying on ground -> event two, and third 
    * event upon leaving the ground(jumping)
    * **/
    protected void OnCollisionEnter2D(Collision2D collision) {
      isGrounded = true;
    }
    protected void OnCollisionStay2D(Collision2D collision) {
      isGrounded = true;
    }
    protected void OnCollisionExit2D(Collision2D collision) {
      isGrounded = false;
    }
        //pick up items
        void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
            }
        }

    }

  
}