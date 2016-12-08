using UnityEngine;
using System.Collections;

namespace Platformer {

  //Using inheritance. Character will be the parent class that other classes can inherit from
  public abstract class Character : MonoBehaviour {


    //
    public bool canMove = true;
    public bool canAttack = true;
    public bool interactable = false;

    public Animator characterAnimator;

    //stats
    public int maxHealth = 5;
    public int currentHealth;

    public int defaultDamage = 1;
    public int currentDamage;

    public float defaultMoveSpeed = 0.05f;
    public float currentMoveSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public virtual void Death() {
      if (currentHealth <= 0) {
        //dead
        Destroy(this.gameObject);
      }
    }
  }

}