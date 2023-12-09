using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private GameObject projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (projectile != null)
            {
                transform.position = projectile.transform.position;
                Destroy(projectile);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Spawn projectile depending on the difference between the mouse position and the player position
            Vector3 playerPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 direction = Input.mousePosition - playerPosition;
            direction = new Vector3(direction.x, direction.y, 0).normalized;
            projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.forward = direction;
        }
    }
}
