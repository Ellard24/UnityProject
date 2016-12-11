using UnityEngine;
using System.Collections;
namespace Platformer
{
    public class PlayerWarp : MonoBehaviour
    {
        void Start()
        {

        }

        //Warp player to coordinates 
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag ("Player"))
            {
                other.transform.position = new Vector3(7, 2, 0);

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
