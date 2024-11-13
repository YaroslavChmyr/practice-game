using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform[] Points;
    [SerializeField] float reachThreshold = 0.1f; // Distance to consider as "reached" a point

    int pointsIndex;

    void Start()
    {
        transform.position = Points[pointsIndex].position;
    }

    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            // Move towards the target point
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].position, moveSpeed * Time.deltaTime);

            // Check if the distance to the target point is small enough
            if (Vector2.Distance(transform.position, Points[pointsIndex].position) < reachThreshold)
            {
                pointsIndex += 1;
            }
        }
    }
}
