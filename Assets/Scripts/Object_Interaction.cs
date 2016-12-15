using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Platformer {
  public class Object_Interaction : MonoBehaviour {

    //variable for Player GameObject
    public GameObject Player;
    //variable for PM component of Player
    public Player_Manager PM;
    //variable to track whether object is interacting with player
    public bool interacting = false;
    //variable tracking distance between object and player
    public Vector2 distance;

    //variable checking whether interactable object can move
    public bool moveableObject;
    //variable that checks if object is moving
    public bool currentlyMoving;

    //variable for passed in player x coordinate
    public float playerX;
    //variable specified in inspector that checks if object is a seasonal object
    public bool seasonal;
    //checks if object is destroyable. Used for when we need to cancel out DontDestroyOnLoad
    public bool destroyable = false;
    //checks if object has been created. Used for when seasonal shifts happen to stop duplicateo objects
    public bool created = false;

    // Use this for initialization
    void Start() {
      Player = GameObject.Find("Player");
      PM = Player.GetComponent<Player_Manager>();

      //if a scene is loaded and a duplicate object is found. Destroy it
      if (GameObject.Find(this.name).GetComponent<Object_Interaction>().created == true) {
        Destroy(this.gameObject);
      }
      created = true;
    }

    // Update is called once per frame
    void Update() {
      
      //Keeps the object moving to follow the player
      if (currentlyMoving) {
        moving();
      }

      //If seasonal and currently "attached" to player, make it carry over to next season
      if (seasonal && interacting) {
        DontDestroyOnLoad(this.gameObject);
      } else {
        destroyable = true;
      }


    }

    void OnDisable() {
      SceneManager.sceneUnloaded -= levelChange;
    }

    void OnEnable() {
      SceneManager.sceneUnloaded += levelChange;
    }

    /**
     * 
     * Function used to carry out destroying an object 
     * that was not destroyable before.
     * 
     * */
    void levelChange(Scene newScene) {
      if (destroyable == true) {
        Destroy(gameObject);
      }
    }


    /**
     * 
     * Checks players movement vector.x direction that 
     * gets passed in. Moves object in appropriate 
     * direction based on that.
     * */
    public void moving() {

      if (playerX == -1) {
        distance = new Vector3(Player.transform.position.x - .5f, Player.transform.position.y);
      } else if (playerX == 1) {
        distance = new Vector3(Player.transform.position.x + .5f, Player.transform.position.y);
      }

      transform.position = Vector2.MoveTowards(transform.position, distance, .1f);
    }

    /**
     * 
     * Upon player interacting with an object this function
     * gets called. Sets the appropriate values for variables
     * relating to what type of object it is. Also resets
     * values when cancelling an interaction
     * */
    public void playerInteraction(float last_x) {
      
      if (!interacting && moveableObject) {
        currentlyMoving = true;
        interacting = true;
        destroyable = false;
        playerX = last_x;
      } else if (interacting && moveableObject) {
        interacting = false;
        currentlyMoving = false;
        destroyable = false;
        created = false;
        PM.interactionTarget = null;
      }else {
        interacting = false;
      }



    }
  }
}