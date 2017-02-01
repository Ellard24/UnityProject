using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBear : MonoBehaviour {

    public Transform target1;
    public Transform target2;
    public float speed;

    void Start()
    {
        StartCoroutine(PaceMovement());
    }
    // Update is called once per frame
    IEnumerator PaceMovement () {
        float step = speed * Time.deltaTime;
        bool arrived = false;
        transform.position = Vector3.MoveTowards(transform.position, target1.position, step);

        while (!arrived)
        {
            transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
            if (Vector3.Distance(transform.position, target1.position) == 0) arrived = true;
            yield return null;
        }


        if (arrived)
        {
            yield return new WaitForSeconds(5);
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }

    }
}
