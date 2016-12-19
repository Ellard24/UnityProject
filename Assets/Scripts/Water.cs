using UnityEngine;
using System.Collections;

namespace Platformer {
  public class Water : MonoBehaviour {

    public SceneChanger SC;
    public GameObject Player;


    // Use this for initialization
    void Start() {
      SC = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
      Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

 
    private void OnTriggerEnter2D(Collider2D other) {
      Player.GetComponent<PlayerMovement>().isSwimming = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
      Player.GetComponent<PlayerMovement>().isSwimming = false;
    }

  }
}
