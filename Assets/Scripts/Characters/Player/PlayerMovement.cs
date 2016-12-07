using UnityEngine;
using System.Collections;

namespace Platformer {
  public class PlayerMovement : MonoBehaviour {

    //Variables that correspond to certain components attached to object
    private Rigidbody2D rBody;
    private Animator anim;
    private Player_Manager PlayerManager;

    public float playerSpeed;
    public Vector2 movementVector;

    public float jumpHeight;
    public bool isGrounded = false;

    // Use this for initialization
    void Start() {

      jumpHeight = 500f;
      PlayerManager = GetComponent<Player_Manager>();
      rBody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();

      //movement speed is a float that we multiply by Time.deltaTime;
      playerSpeed = PlayerManager.defaultMoveSpeed * Time.deltaTime;
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
        rBody.MovePosition(rBody.position + (movementVector * playerSpeed));
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

        playerSpeed = PlayerManager.currentMoveSpeed * Time.deltaTime;
      }
    }

    private void jump() {
      rBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Force);
    }

    protected void OnCollisionEnter2D(Collision2D collision) {
      isGrounded = true;
    }
    protected void OnCollisionStay2D(Collision2D collision) {
      isGrounded = true;
    }
    protected void OnCollisionExit2D(Collision2D collision) {
      isGrounded = false;
    }
  }

  
}