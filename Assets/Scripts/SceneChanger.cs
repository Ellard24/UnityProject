using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Platformer {

  public class SceneChanger : MonoBehaviour {

    public GameObject Player;

    private static bool created = false;
      
    public string currentScene;
    public string nextScene;
    private Vector2 playerCoords;

    public KeyCode seasonChange = KeyCode.LeftShift;


    //This will make sure we dont ever have more than one scene changer object
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

      if (Input.GetKeyDown(seasonChange)) {
        changeScene();
      }
    }
    /* 
     * OnRenderObject gets called every time a scene loads and is much more useful
     * than Update() when dealing with scene changes because it won't get called a million times
     */
    void OnRenderObject() {

      // Identify the current scene by name
      currentScene = SceneManager.GetActiveScene().name;
    }

    private void changeScene() {
      playerCoords = Player.transform.position;

      //we will use a specific naming convention to streamline scene changes. 
      //This way we can keep each set of scenes per level compartmentalized 
      sceneNameChanger();
      //fadeEffect();
      SceneManager.LoadScene(nextScene);
      spawnPlayerInNewScene();
    }

    IEnumerator fadeEffect() {
      ScreenFader sf = GameObject.Find("ScreenFader").GetComponent<ScreenFader>();
      yield return StartCoroutine(sf.FadeToBlack());
      yield return StartCoroutine(sf.FadeToClear());
    }

    private void spawnPlayerInNewScene() {
      
      //we will need to add some kind of checking system to ensure the player doesnt spawn in a bad location
      Player.transform.position = playerCoords;
    }

    /*
     * Takes the current scene name and creates the appropriate name for nextScene so 
     * that the scene manager can appropriately change scenes
     * */
    private void sceneNameChanger() {
      if (currentScene.Contains("Spring")) {
        string[] strArr = currentScene.Split(new string[] {"Season"}, System.StringSplitOptions.None);
        nextScene = string.Format("{0}SeasonWinter", strArr[0]);
      }else if (currentScene.Contains("Winter")) {
        string[] strArr = currentScene.Split(new string[] { "Season" }, System.StringSplitOptions.None);
        nextScene = string.Format("{0}SeasonSpring", strArr[0]);
      }
    }
  }
}