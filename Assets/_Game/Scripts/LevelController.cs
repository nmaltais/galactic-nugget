using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  private Level _level;
  private int _TotalAsteroidsSpawned = 0;
  private Queue<Level> _levels = new Queue<Level>();

  void Awake() {
    SetupLevels(); 
  }
  // Start is called before the first frame update
  void Start()
  {
    NextLevel(); // Play level 1
    GameEvents.current.OnAsteroidDestroyed += CheckIfLevelCleared;
  }

  private void NextLevel() {
    _TotalAsteroidsSpawned = 0;
    _level = _levels.Dequeue();
    
    if(AsteroidsGenerator.current != null) {
      for(int i=0; i < _level.maxAsteroids; i++) {
        AsteroidsGenerator.current.CreateAsteroid(_level.minSpeed, _level.maxSpeed, _level.maxLives);
        _TotalAsteroidsSpawned++;
      }
    }
    
  }

  private void CheckIfLevelCleared(Asteroid destoyedAsteroid) {
    Asteroid[] _asteroids = FindObjectsOfType<Asteroid>();
    if(_TotalAsteroidsSpawned < _level.numAsteroids) {
      AsteroidsGenerator.current.CreateAsteroid(_level.minSpeed, _level.maxSpeed, _level.maxLives);
      _TotalAsteroidsSpawned++;
      return;
    }
    foreach(Asteroid a in _asteroids) {
      if(a == destoyedAsteroid) continue;
      if(a != null) return;
    }

    if(_levels.Count > 0) {
      NextLevel();
      GameEvents.current.LevelChanged(_level);
    } 
    else {
      print("GAME OVER");
      GameEvents.current.PlayerWon();
    }
  }

  private void SetupLevels() {
    _levels.Enqueue(new Level {id=1, numAsteroids = 3, maxAsteroids = 3, minSpeed = 5, maxSpeed = 10, maxLives = 1});
    _levels.Enqueue(new Level {id=1, numAsteroids = 5, maxAsteroids = 2, minSpeed = 5, maxSpeed = 10, maxLives = 1});
    _levels.Enqueue(new Level {id=2, numAsteroids = 6, maxAsteroids = 3, minSpeed = 6, maxSpeed = 10, maxLives = 1});
    _levels.Enqueue(new Level {id=3, numAsteroids = 6, maxAsteroids = 3, minSpeed = 6, maxSpeed = 10, maxLives = 2});
    _levels.Enqueue(new Level {id=4, numAsteroids = 5, maxAsteroids = 4, minSpeed = 7.5f, maxSpeed = 10, maxLives = 2});
    _levels.Enqueue(new Level {id=5, numAsteroids = 10, maxAsteroids = 4, minSpeed = 8, maxSpeed = 10, maxLives = 2});
  }

  void OnDestroy() {
    GameEvents.current.OnAsteroidDestroyed -= CheckIfLevelCleared;
  }


}

public class Level {
  public int id;
  public int numAsteroids;
  public int maxAsteroids;
  public float minSpeed;
  public float maxSpeed;
  public int maxLives;
}

