using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FoodSpawnerLogic : MonoBehaviour
{
    public GameObject foodPrefab;

    public float spawnFrequency = 0.5f;

    public int maxEntities = 20;

    public int minOffscreenDistance = 0;
    public int maxOffscreenDistance = 40;

    private float _minDistance;

    private float _maxSqrDistance;

    private void Start()
    {
        var screenCenterPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
        var cornerPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        _minDistance = minOffscreenDistance + Vector2.Distance(screenCenterPos, cornerPos);
        _maxSqrDistance = (float) Math.Pow(_minDistance + maxOffscreenDistance, 2);

        InvokeRepeating(nameof(FoodPeriodicCheck), spawnFrequency, spawnFrequency);
    }

    private void FoodPeriodicCheck()
    {
        if (transform.childCount >= maxEntities)
        {
            var screenCenterPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);

                if (Vector2.Distance(child.position, screenCenterPos) > _minDistance + maxOffscreenDistance)
                {
                    Destroy(transform.GetChild(i).gameObject);
                    SpawnFood();
                    break;
                }
            }
        }
        else
        {
            SpawnFood();
        }

    }

    private GameObject SpawnFood()
    {
        var screenCenterPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));

        var radius = _minDistance + Random.value * maxOffscreenDistance;
        var angle = Random.value * Mathf.PI * 2;

        var x = (float)Math.Cos(angle) * radius + screenCenterPos.x;
        var y = (float)Math.Sin(angle) * radius + screenCenterPos.y;
        var pos = new Vector2(x, y);

        return Instantiate(foodPrefab, pos, Quaternion.identity, gameObject.transform);
    }
}
