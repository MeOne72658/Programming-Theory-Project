using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    [SerializeField]
    private Transform playerGameObjectTransform;
    [SerializeField]
    private GameEnding gameEndingObject;

    private bool m_IsPlayerInRange = false;

    public bool PlayerInRange 
    { 
        get
        {
            return m_IsPlayerInRange;
        } 
    }

    public GameEnding GameEnder 
    { 
        get
        {
            return gameEndingObject;
        } 
    }

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
    }

    public bool PlayerDetected()
    {
        bool returnVal = false;
        if (m_IsPlayerInRange)
        {
            Debug.Log(m_IsPlayerInRange);
            Vector3 direction = playerGameObjectTransform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit rayCastHit;
            if (Physics.Raycast(ray, out rayCastHit))
            {
                if (rayCastHit.collider.transform == playerGameObjectTransform)
                {
                    returnVal = true;
                }
            }
        }
        return returnVal;
    }
}
