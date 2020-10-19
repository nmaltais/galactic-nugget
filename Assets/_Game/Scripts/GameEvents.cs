using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake() {
      if(current == null)
      {
        current = this;
        DontDestroyOnLoad(gameObject);
      }
      else if (current != this)
      {
        Destroy(gameObject);
      }
    }

    //Player Actions 
    public event Action OnPlayerRotateLeft;
    public void PlayerRotateLeft() {
      OnPlayerRotateLeft?.Invoke();
    }
    public event Action OnPlayerRotateRight;
    public void PlayerRotateRight() {
      OnPlayerRotateRight?.Invoke();
    }
    public event Action OnPlayerMoveForward;
    public void PlayerMoveForward() {
      OnPlayerMoveForward?.Invoke();
    }
    public event Action OnPlayerShoot;
    public void PlayerShoot() {
      OnPlayerShoot?.Invoke();
    }

    //Menu
    public event Action OnTogglePause;
    public void TogglePause() {
      OnTogglePause?.Invoke();
    }


    
    //Bullet Hit Asteroid
    public event Action<Asteroid, Vector3> OnAsteroidHit;
    public void AsteroidHit(Asteroid asteroid, Vector3 collisionPoint) {
      OnAsteroidHit?.Invoke(asteroid, collisionPoint);
    }

    //Rocket Hit Asteroid
    public event Action<Asteroid, Vector3> OnRocketHitAsteroid;
    public void RocketHitAsteroid(Asteroid asteroid, Vector3 collisionPoint) {
      OnRocketHitAsteroid?.Invoke(asteroid, collisionPoint);
    }

    //Asteroid Destroyed
    public event Action<Asteroid> OnAsteroidDestroyed;
    public void AsteroidDestroyed(Asteroid a) {
      OnAsteroidDestroyed?.Invoke(a);
    }
    
    //Score Changed
    public event Action<float> OnScoreChanged;
    public void ScoreChanged(float score) {
      OnScoreChanged?.Invoke(score);
    }
    //Cleared Level
    public event Action OnLevelCleared;
    public void LevelCleared() {
      OnLevelCleared?.Invoke();
    }
    //Level Changed
    public event Action<Level> OnLevelChanged;
    public void LevelChanged(Level level) {
      OnLevelChanged?.Invoke(level);
    }
    //Game Over - Player Won
    public event Action OnPlayerWon;
    public void PlayerWon() {
      OnPlayerWon?.Invoke();
    }
}
