using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public float speed = 2f;
    public bool move = false;
    private Transform currentTarget;
    private int countDone = 0;

    void Start()
    {
        if (move)
        {   
            // Initialize the current target based on the defined points
            if (pointA != null)
                currentTarget = pointA;
            else if (pointB != null)
                currentTarget = pointB;
            else if (pointC != null)
                currentTarget = pointC;
            else if (pointD != null)
                currentTarget = pointD;
            else
            {
                Debug.LogError("No points defined for platform movement!");
                move = false;
                currentTarget = null;
            }
        }
    }

    void Update()
    {
        if (move && currentTarget != null)
        {
            // Move towards the current target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
            countDone++;
            // Check if the platform has reached the current target
            if (countDone == 12)
            {
                Debug.Log(Vector3.Distance(transform.position, currentTarget.position).ToString());
                countDone = 0;
            }
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
            {
                // Update the current target based on the next defined point
                if (currentTarget == pointA)
                    currentTarget = pointB != null ? pointB : pointC != null ? pointC : pointD;
                else if (currentTarget == pointB)
                    currentTarget = pointC != null ? pointC : pointD != null ? pointD : pointA;
                else if (currentTarget == pointC)
                    currentTarget = pointD != null ? pointD : pointA != null ? pointA : pointB;
                else if (currentTarget == pointD)
                    currentTarget = pointA != null ? pointA : pointB != null ? pointB : pointC;
            }
        }
    }
}
