using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPosition : MonoBehaviour
{
    private SnakeTail snikeTail;
    private Food food;
    private Snike snike;

    public static bool eat = false;

    private void Start()
    {
        snikeTail = FindObjectOfType<SnakeTail>();
        food = FindObjectOfType<Food>();
        snike = FindObjectOfType<Snike>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
            food.SpawnFood();
            snikeTail.AddBody();
            snike.gridMoveTimerMax += 0.05f;
        }
    }
}
