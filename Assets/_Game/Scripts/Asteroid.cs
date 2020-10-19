using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody _rb;
    private Collider _col;
    [SerializeField] private GameObject _hitParticlePrefab = null; //Attached in the Editor
    [SerializeField] private GameObject _destroyedParticlePrefab = null; //Attached in the Editor
    private float _scoreValue = 10;
    private Vector3 _force = new Vector3(0,0,0);
    private Vector3 _torque = new Vector3(0,0,0);
    private float _health = 2;
    Camera MainCamera;
     
    // Start is called before the first frame update
    void Start()
    {
      _rb = GetComponent<Rigidbody>();
      _col = GetComponent<Collider>();
      MainCamera = Camera.main;
      GameEvents.current.OnAsteroidHit += damage;
      setInMotion(_force, _torque);
    }

    public void setInMotion(Vector3 force, Vector3 torque) {
      _rb.AddForce(_force);
      _rb.AddTorque(_torque);
    }

    public void setForce(Vector3 force) {
      _force = force;
    }
    public void setTorque(Vector3 torque) {
      _torque = torque;
    }
    public void setLives(int lives) {
      _health = lives;
    }
    

    public float getScoreValue() {
      return _scoreValue;
    }

    public void damage(Asteroid a, Vector3 contactPos) {
      if(a == this) {
        _health -= 1;
        
        if(_health > 0) {
          //Hit
          Instantiate(_hitParticlePrefab, contactPos, Quaternion.identity);
        } else {
          //Destroyed
          Instantiate(_destroyedParticlePrefab, contactPos, Quaternion.identity);
          GameEvents.current.AsteroidDestroyed(this);
          GameEvents.current.OnAsteroidHit -= damage;
          Destroy(gameObject);
        }
      }
    }
}
