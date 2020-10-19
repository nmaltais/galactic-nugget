using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour
{
    public static AsteroidsGenerator current;
    [SerializeField] private Transform[] pfAsteroids = null; //Attached in the Editor

    void Awake() {
      current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
      // current = this;
    }

    internal void CreateAsteroid(float minSpeed, float maxSpeed, int maxLives) {
      Vector3 screenBoundsTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
      Vector3 screenBoundsBot = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, Camera.main.transform.position.z));
      Vector3 randomPointOnScreen = new Vector3(Random.Range(screenBoundsBot.x, screenBoundsTop.x), Random.Range(screenBoundsBot.y, screenBoundsTop.y));
      float objSize = 15;

      Vector3 pos1 = new Vector3(screenBoundsTop.x - objSize, Random.Range(screenBoundsBot.y, screenBoundsTop.y));
      Vector3 pos2 = new Vector3(screenBoundsBot.x + objSize, Random.Range(screenBoundsBot.y, screenBoundsTop.y));
      Vector3 pos3 = new Vector3(Random.Range(screenBoundsBot.x, screenBoundsTop.x), screenBoundsTop.y - objSize);
      Vector3 pos4 = new Vector3(Random.Range(screenBoundsBot.x, screenBoundsTop.x), screenBoundsBot.y + objSize);
      Vector3[] pos = new Vector3[] {pos1, pos2, pos3, pos4};
      int randIdx2 = Random.Range(0, 4);
      Vector3 dir = pos[randIdx2] - randomPointOnScreen;
      
      Vector3 force =  dir * Random.Range(minSpeed, maxSpeed) + (pos[randIdx2] - new Vector3(0,0,0)) * 3f ;
      Vector3 torque = new Vector3(Random.Range(-100,100), Random.Range(-100,100), Random.Range(-100,100));

      int randIdx = Random.Range(0, pfAsteroids.Length);
      Transform asteroid = Instantiate(pfAsteroids[randIdx], pos[randIdx2], Quaternion.identity);
      asteroid.transform.localScale = asteroid.transform.localScale * Random.Range(0.4f, 0.8f);
      asteroid.GetComponent<Asteroid>().setTorque(torque);
      asteroid.GetComponent<Asteroid>().setForce(force);
      asteroid.GetComponent<Asteroid>().setLives(maxLives);
    }
}
