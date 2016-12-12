using UnityEngine;
using System.Collections;

namespace Platformer {
  public class WaterAndIce : MonoBehaviour {

    public SceneChanger SC;


    // Use this for initialization
    void Start() {
      SC = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
      changeCollider();
    }

    // Update is called once per frame
    void Update() {

    }

    private void changeCollider() {
      if (SC.currentSeason == "Spring") {
        GetComponent<BoxCollider2D>().enabled = false;
      } else {
        GetComponent<BoxCollider2D>().enabled = true;
      }


    }

  }
}
