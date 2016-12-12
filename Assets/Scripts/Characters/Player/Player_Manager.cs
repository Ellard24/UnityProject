using UnityEngine;
using System.Collections;


namespace Platformer {
  public class Player_Manager : Character {

    private static bool created = false;
    public bool hasKey = false;

    void Awake() {
      if (!created) {
        DontDestroyOnLoad(this.gameObject);
        created = true;
      } else
        Destroy(this.gameObject);
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Key"))
            {
                hasKey = true;
            }
        }
    // Use this for initialization
    void Start() {

    }

      
            // Update is called once per frame
    void Update()
        {
           

    }
  }
}