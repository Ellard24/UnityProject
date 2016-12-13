using UnityEngine;
using System.Collections;

namespace Platformer {
  public class Object_Interaction : MonoBehaviour {


    public GameObject Player;
    public Player_Manager PM;
    public bool interacting = false;
    public Vector2 distance;

    public bool moveableObject;
    public bool currentlyMoving;
    public float playerX;

    // Use this for initialization
    void Start() {
      Player = GameObject.Find("Player");
      PM = Player.GetComponent<Player_Manager>();
    }

    // Update is called once per frame
    void Update() {

      if (currentlyMoving) {
        moving();
      }

    }

    public void moving() {

      if (playerX == -1) {
        distance = new Vector3(Player.transform.position.x - .5f, Player.transform.position.y);
      } else if (playerX == 1) {
        distance = new Vector3(Player.transform.position.x + .5f, Player.transform.position.y);
      }

      transform.position = Vector2.MoveTowards(transform.position, distance, .1f);
    }


    public void playerInteraction(float last_x) {
      
      if (!interacting && moveableObject) {
        currentlyMoving = true;
        interacting = true;
        playerX = last_x;
      } else if (interacting && moveableObject) {
        interacting = false;
        currentlyMoving = false;
      }else {
        interacting = false;
      }



    }
  }
}