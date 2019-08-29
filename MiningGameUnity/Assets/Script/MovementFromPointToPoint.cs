using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFromPointToPoint : MonoBehaviour
{

    #region variables
    public Vector2 startPoint;
    public Vector2 endPoint;

    public float movementSpeed;
    public float minXOffset;
    public float maxXOffset;
    public float minYOffset;
    public float maxYOffset;
    public int totalPoints;
    public float errorDistance;

    private int currentPoint;
    private Vector2 step;
    private Vector2 destinationPoint;
    private Vector2 prevPoint;
    #endregion

    #region functions
    private void Start()
    {
        transform.position = startPoint;
        if (totalPoints != 0)
        {
            step = (endPoint - startPoint) / totalPoints;
            currentPoint = 1;
            prevPoint = startPoint;
            destinationPoint = Dest();
        }
        else
        {
            Debug.Log("Не задано количество точек для движения");
        }
    }

    private void Update()
    {
        float absX = Mathf.Abs(destinationPoint.x - transform.position.x);
        float absY = Mathf.Abs(destinationPoint.y - transform.position.y);
        if (absX < errorDistance && absY < errorDistance)
        {
            prevPoint = destinationPoint;
            destinationPoint = Dest();
            currentPoint++;
        }
        if (currentPoint <= totalPoints)
        {
            transform.position += (Vector3)(destinationPoint - prevPoint) * movementSpeed * Time.deltaTime;
        }
        Debug.Log(currentPoint);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, destinationPoint);
        Debug.DrawLine(prevPoint, destinationPoint, Color.green, 100f);
    }

    Vector2 Dest()
    {
        Vector2 normalPoint = startPoint + step * currentPoint;
        Vector2 offset = new Vector2(Random.Range(minXOffset, maxXOffset), Random.Range(minYOffset, maxYOffset));
        return normalPoint + offset;
    }
    #endregion
}
