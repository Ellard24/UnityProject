using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Platformer {

  public class SceneChanger : MonoBehaviour {

    public GameObject Player;

    private static bool created = false;

    public string currentScene;
    public string nextScene;

    void Awake() {
      if (!created) {
        DontDestroyOnLoad(this.gameObject);
        created = true;
      } else
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start() {
      Player = GameObject.Find("Player");
      currentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update() {

    }
    /* 
     * OnRenderObject gets called every time a scene loads and is much more useful
     * than Update() when dealing with scene changes because it won't get called a million times
     */
    void OnRenderObject() {

      // Identify the current scene by name
      currentScene = SceneManager.GetActiveScene().name;
    }

    private void spawnPlayerInNewScene(GameObject Player, Vector2 PlayerSpawnPoint) {
      // Debug.Log(PlayerSpawnPoint.transform.position.x);
      // Debug.Log(PlayerSpawnPoint.transform.position.y);

      Player.transform.position = PlayerSpawnPoint;
    }




  }
}