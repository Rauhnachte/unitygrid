using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private WorldGrid worldGridIndex; // World Grid Index is collected by GameManager GameObject
    
    private float gridInterval; // Takes the value from worldGridIndex
    
    [SerializeField] Vector3 additionalCoordinateIndex; // Exceptional Grid Addition
    
    private Vector3 gridPosition; // Final and true location of the object

    private void Start()
    {
        gridInterval = worldGridIndex.GridInterval; // Get the world Grid Interval Size
    }
    
    void Update()
    {
        PositionIndex();
        transform.position = gridPosition;
    }
    
    /// <summary>
    /// It injects into the grid to exact location without any exceptions.
    /// </summary>
    /// <param name="value">The value stands for position of the object.</param>
    /// <param name="interval">The interval stands for the world's grid interval.</param>
    /// <returns>The exact(true) world location.</returns>
    float GetTrueValueOf(float value, float interval) 
    {
        return Mathf.Floor(value / interval) * interval;
    }

    /// <summary>
    /// It injects into the grid to exact location with exceptions which described in line 50
    /// </summary>
    /// <param name="value">The value stands for position of the object.</param>
    /// <param name="interval">The interval stands for the world's grid interval.</param>
    /// <param name="additional">It adds the exception value into the operation.</param>
    /// <returns>The exact(true) world location.</returns>
    float GetTrueValueOf(float value, float interval, float additional)
    {
        return Mathf.Floor(value / interval) * interval + additional;
    }

    /// <summary>
    /// Return the object's true location
    /// </summary>
    void PositionIndex()
    {
        if (additionalCoordinateIndex.x != 0)
        {
            gridPosition.x = GetTrueValueOf(transform.position.x, gridInterval, additionalCoordinateIndex.x);
            gridPosition.y = GetTrueValueOf(transform.position.y, gridInterval);
            gridPosition.z = GetTrueValueOf(transform.position.z, gridInterval);
        } // Exception for X
        
        else if (additionalCoordinateIndex.y != 0)
        {
            gridPosition.x = GetTrueValueOf(transform.position.x, gridInterval);
            gridPosition.y = GetTrueValueOf(transform.position.y, gridInterval, additionalCoordinateIndex.y);
            gridPosition.z = GetTrueValueOf(transform.position.z, gridInterval);
        } // Exception for Y
        
        else if (additionalCoordinateIndex.z != 0)
        {
            gridPosition.x = GetTrueValueOf(transform.position.x, gridInterval);
            gridPosition.y = GetTrueValueOf(transform.position.y, gridInterval);
            gridPosition.z = GetTrueValueOf(transform.position.z, gridInterval, additionalCoordinateIndex.z);
        } // Exception for Z

        else
        {
            gridPosition.x = GetTrueValueOf(transform.position.x, gridInterval);
            gridPosition.y = GetTrueValueOf(transform.position.y, gridInterval);
            gridPosition.z = GetTrueValueOf(transform.position.z, gridInterval);
        } // No Exception
    }
}
