using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Transform enemy; // Reference to the player or enemy
    public Light targetLight; // Reference to the light you want to control
    public float detectionRadius = 20f; // Distance at which the light starts changing color
    public Color redColor = Color.red; // Color to transition to when the enemy is near
    public Color originalColor = Color.white; // Original color of the light

    void Update()
    {
        // Calculate the distance between the light and the player/enemy
        float distanceToPlayer = Vector3.Distance(transform.position, enemy.position);

        // Gradually change light color based on distance
        if (distanceToPlayer <= detectionRadius)
        {
            float t = Mathf.InverseLerp(0, detectionRadius, distanceToPlayer);
            Color lerpedColor = Color.Lerp(originalColor, redColor, t);
            targetLight.color = lerpedColor;
        }
        else
        {
            // If the player/enemy is away, gradually return to the original color
            targetLight.color = Color.Lerp(targetLight.color, originalColor, Time.deltaTime);
        }
    }
}
