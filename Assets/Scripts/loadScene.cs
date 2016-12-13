using UnityEngine;
using System.Collections;

namespace Platformer {
  public class loadScene : MonoBehaviour {


    public GameObject Player;
    public SceneChanger SC;

    // Use this for initialization
    void Start() {
      Player = GameObject.Find("Player");
      SC = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
      if (!SC.justChanged) {
        Player.transform.position = transform.position;
      }else {
        SC.justChanged = false;
      }
    }

    // Update is called once per frame
    void Update() {

    }
  }

}