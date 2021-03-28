using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPosition : MonoBehaviour
{
    private SnakeTail snike;
    private Food food;

    public static bool eat;

    private void Start()
    {
        snike = FindObjectOfType<SnakeTail>();
        food = FindObjectOfType<Food>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            eat = true;
            Debug.Log("11111");
            Destroy(gameObject);
            food.SpawnFood();
            snike.AddBody();
        }
    }
}
