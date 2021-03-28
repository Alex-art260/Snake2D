using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snike : MonoBehaviour
{

    private Vector2Int gridMoveDirection;
    private Vector2Int gridPozition;
    public float gridMoveTimer;
    public float gridMoveTimerMax;



    private void Awake()
    {
        gridPozition = new Vector2Int(10, 10);
        gridMoveTimerMax = 1f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);
    }

    private void Start()
    {
        StartCoroutine(NormalSpeedSnake());
    }



    private void Update()
    {
        HandleInput();
        HandleGridMovement();
        
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gridMoveDirection.y != +1)
            {
                gridMoveDirection.x = 0;
                gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gridMoveDirection.x != +1)
            {
                gridMoveDirection.x = -1;
                gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection.x = +1;
                gridMoveDirection.y = 0;
            }
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridPozition += gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;

            transform.position = new Vector3(gridPozition.x, gridPozition.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
        }
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Board")
        {
            Debug.Log("Lose");
        }
    }

    IEnumerator NormalSpeedSnake()
    {
        while(true)
        {

            if (Time.timeSinceLevelLoad > 5f)
            {
                gridMoveTimerMax -= 0.05f;
            }

            yield return new WaitForSeconds(5f);
        }

        
    }


}
