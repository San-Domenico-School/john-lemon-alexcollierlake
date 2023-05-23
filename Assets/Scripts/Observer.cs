using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Observer.
 * 
 * Alexandra Collier-Lake
 * 05/23/2023
 */

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameEnding gameEnding;
    private bool isPlayerInRange;

    // Update is called once per frame
     void Update()
    {
        CanGargoyleSeePlayer();
    }

    private void CanGargoyleSeePlayer()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if(other.transform == player)
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            isPlayerInRange = false;
        }
    }


}
