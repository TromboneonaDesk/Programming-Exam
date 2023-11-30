using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    Rigidbody rb;
    float fallDelay = 0.5f;
    float destroyDelay = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private IEnumerator OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print(collision.gameObject);
            yield return new WaitForSeconds(fallDelay);
            rb.constraints = RigidbodyConstraints.None;
            yield return new WaitForSeconds(destroyDelay);
            Destroy(gameObject);
        }
    }
}
