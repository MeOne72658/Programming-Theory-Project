using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargoyle : Observer
{
    [SerializeField]
    private float detectionRange = 1;

    private CapsuleCollider sightLine;
    // Start is called before the first frame update
    void Start()
    {
        sightLine = GetComponent<CapsuleCollider>();
        sightLine.height = detectionRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetected())
        {
            GameEnder.PlayerCaught();
        }
    }
}
