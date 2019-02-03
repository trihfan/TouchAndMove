using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
    // 2 - Store the movement
    private Vector2 movement;

    private Vector2 _lastPosition;

    void Update()
    {
        // Touchscreen input
        // Look for all fingers
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // -- Drag
            // ------------------------------------------------
            if (touch.phase == TouchPhase.Moved)
            {
                    movement = new Vector2(0, touch.deltaPosition.y * 4);
            }
        }

        // 5 - Shooting
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // false because the player is not an enemy
                weapon.Attack(false);
            }
        }

    }

    void FixedUpdate()
    {
        // 5 - Move the game object
        rigidbody2D.velocity = movement;
    }
}