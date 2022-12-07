using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]EnemyCounter enemyCouner;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCouner.lastRoundEnded)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Random.Range(0, 5), 0, Random.Range(0,5));
        }
    }
}
