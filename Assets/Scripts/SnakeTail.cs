using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform snakeHead;
    public float CircleDiametr;

    private List<Transform> snakeBody = new List<Transform>();
    private List<Vector2> positions = new List<Vector2>();


    void Start()
    {
        positions.Add(snakeHead.position);
    }


    void FixedUpdate()
    {
        float distance = ((Vector2)snakeHead.position - positions[0]).magnitude;
        if (distance > CircleDiametr)
        {
             Vector2 direction = ((Vector2) snakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiametr);
            positions.RemoveAt(positions.Count - 1);
            distance -= CircleDiametr;
        }

        for (int i = 0; i < snakeBody.Count; i++)
        {
            snakeBody[i].position = Vector2.Lerp(positions[i + 1], positions[i], distance / CircleDiametr);
        }
    }
     
    public void AddBody()
    {
        Transform body =  Instantiate(snakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeBody.Add(body);
        positions.Add(body.position);
        body.gameObject.tag = "Body";
    }
}
