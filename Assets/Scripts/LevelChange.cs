using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Platformer {

  public class LevelChange : MonoBehaviour {

    public SceneChanger SC;

    // Use this for initialization
    void Start() {
      SC = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update() {

    }


    void OnTriggerEnter2D(Collider2D other) {

      if (other.gameObject.name == "Player") {

        //we need a way to change scene to the appropriate level
        SceneManager.LoadScene(this.gameObject.name);
        
      }
    }

  }
}