using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Transform playerGameObjectTransform;
    [SerializeField]
    private GameEnding gameEndingObject;

    private bool m_IsPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == playerGameObjectTransform)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == playerGameObjectTransform)
        {
            m_IsPlayerInRange = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = playerGameObjectTransform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit rayCastHit;
            if (Physics.Raycast(ray, out rayCastHit))
            {
                if(rayCastHit.collider.transform == playerGameObjectTransform)
                {
                    gameEndingObject.PlayerCaught();
                }
            }
        }
    }
}
