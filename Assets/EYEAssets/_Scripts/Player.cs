using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 3;
    public GameObject projectilePrefab;
        
    public void MovePlayer (Vector2 direction)
    {
        transform.Translate(new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime);
    }
    
    public void FireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
