using UnityEngine;
using System.Collections;
namespace Platformer
{
    
    public class PlayerWarp : MonoBehaviour
    {
        private static bool playerHasKey;
        public GameObject Player;
        void Start()
        {
            Player = GameObject.Find("Player");
        }
      

        //Warp player to coordinates if Player has picked up key
        void OnTriggerEnter2D(Collider2D other)
        {
           
            if (playerHasKey == true && other.gameObject.CompareTag ("Player"))
            {
                other.transform.position = new Vector3(6, 2, 0);

            }
        }

        // Update is called once per frame
        void Update()
        {
            playerHasKey = Player.GetComponent<PlayerMovement>().hasKey;

        }
    }
}
