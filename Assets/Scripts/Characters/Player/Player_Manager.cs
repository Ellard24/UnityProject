using UnityEngine;
using System.Collections;


namespace Platformer {
  public class Player_Manager : Character {

    private static bool created = false;
    public bool hasKey = false;

    public KeyCode interactButton = KeyCode.E;
    public RaycastHit2D direction;
    public bool currentlyInteracting = false;
    public GameObject interactionTarget;
    public string interactionTargetTag;

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

      if (Input.GetKeyDown(interactButton)) {
        interact();
      }

    }

    public void interact() {

      //performance a raycast in the current direction
      direction = Physics2D.Raycast(transform.position, new Vector2(GetComponent<PlayerMovement>().last_x, 0), 1f);

      //actually perform the interaction is target is acceptable
      if (direction.collider != null && (direction.collider.tag == "Interactable" || direction.collider.tag == "InteractableSeasonal")) {
        currentlyInteracting = true;
        interactionTarget = direction.collider.gameObject;
        interactionTargetTag = direction.collider.tag;
        Debug.Log("it worked");
        direction.collider.gameObject.SendMessage("playerInteraction", GetComponent<PlayerMovement>().last_x, SendMessageOptions.DontRequireReceiver);
      }

    }


  }
}