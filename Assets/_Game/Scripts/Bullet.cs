using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void PhysicsSetup(Vector3 shootDir) {
      float speedMagnitude = 2f;
      rb = GetComponent<Rigidbody>();
      rb.AddForce(shootDir * speedMagnitude, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
      ContactPoint contact = collision.GetContact(0);
      Asteroid asteroid = contact.otherCollider.GetComponent<Asteroid>();
      if (asteroid != null) {
        GameEvents.current.AsteroidHit(asteroid, contact.point);
      } 
        Destroy(gameObject);
    }
}
