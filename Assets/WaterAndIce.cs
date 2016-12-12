using UnityEngine;
using System.Collections;

namespace Platformer {
  public class WaterAndIce : MonoBehaviour {

    public SceneChanger SC;
    public GameObject Player;


    // Use this for initialization
    void Start() {
      SC = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
      Player = GameObject.Find("Player");
      changeCollider();
    }

    // Update is called once per frame
    void Update() {

    }

    private void changeCollider() {
      if (SC.currentSeason == "Spring") {
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());
        GetComponent<Collider2D>().isTrigger = true;
      } else {
        //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Player.GetComponent<Collider2D>(), false);
        GetComponent<Collider2D>().isTrigger = false;
      }


    }

    private void OnTriggerEnter2D(Collider2D other) {
      Player.GetComponent<PlayerMovement>().isSwimming = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
      Player.GetComponent<PlayerMovement>().isSwimming = false;
    }

  }
}
