using UnityEngine;
using System.Collections;

public class loadScene : MonoBehaviour {


  public GameObject Player;

	// Use this for initialization
	void Start () {
    Player = GameObject.Find("Player");
    Player.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
