using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rb;
    private float _maxSpeed = 10;
    [SerializeField] private Transform pfBullet = null; //Attached in the Editor
    [SerializeField] private GameObject _destroyedRocket = null; //Attached in the Editor
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameEvents.current.OnPlayerRotateLeft += RotateLeft;
        GameEvents.current.OnPlayerRotateRight += RotateRight;
        GameEvents.current.OnPlayerMoveForward += MoveForward;
        GameEvents.current.OnPlayerShoot += Shoot;
    }

    void RotateLeft(){
      transform.Rotate(0f, 0f, 1.7f, Space.Self);
    }
    void RotateRight(){
      transform.Rotate(0f, 0f, -1.7f, Space.Self);
    }
    void MoveForward(){
      if(rb.velocity.magnitude > _maxSpeed) {
        rb.velocity = rb.velocity.normalized * _maxSpeed;
      } else {
        rb.AddForce(transform.up * 0.1f, ForceMode.Impulse);
      }
    }
    void Shoot() {
      Transform bulletTransform = Instantiate(pfBullet, transform.position + transform.up * 2.6f, Quaternion.identity);
      bulletTransform.GetComponent<Bullet>().PhysicsSetup(transform.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
      ContactPoint contact = collision.GetContact(0);
      Asteroid asteroid = contact.otherCollider.GetComponent<Asteroid>();
      if (asteroid != null) {
        Instantiate(_destroyedRocket, contact.point, Quaternion.identity);
        GameEvents.current.RocketHitAsteroid(asteroid, contact.point);
        Destroy(gameObject);
      } 
    }

    void OnDestroy() {
        GameEvents.current.OnPlayerRotateLeft -= RotateLeft;
        GameEvents.current.OnPlayerRotateRight -= RotateRight;
        GameEvents.current.OnPlayerMoveForward -= MoveForward;
        GameEvents.current.OnPlayerShoot -= Shoot;
    }
}
