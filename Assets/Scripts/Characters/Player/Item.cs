using UnityEngine;
using System.Collections;

namespace Platformer
{
    public class Item : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
                Destroy(other.gameObject);
        }


        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime); // rotating because it is cool...
        }
    }
}
