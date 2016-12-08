using UnityEngine;
using System.Collections;

namespace Platformer {
  public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float camSpeed = 0.1f;
    Camera mainCam;

    // Use this for initialization
    void Start() {
      mainCam = GetComponent<Camera>();
      target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update() {
      mainCam.orthographicSize = (Screen.width / Screen.height);

      if (target) {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f) + new Vector3(0, 0, -10);
      }
    }
  }
}