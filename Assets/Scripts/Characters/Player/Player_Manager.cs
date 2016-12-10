using UnityEngine;
using System.Collections;


namespace Platformer {
  public class Player_Manager : Character {

    private static bool created = false;

    void Awake() {
      if (!created) {
        DontDestroyOnLoad(this.gameObject);
        created = true;
      } else
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start() {

    }

      
            // Update is called once per frame
    void Update() {

    }
  }
}