using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStack : MonoBehaviour
{
    private const float BoundSize = 3.5f;
    private const float MovingBoundsSize = 3.0f;
    private const float StackMovingSpeed = 5.0f;
    private const float BlockMovingSpeed = 3.5f;
    private const float ErrorMargin = 0.1f;

    public GameObject originBlock = null;

    private Vector3 prevBlockPosition;
    private Vector3 desiraPosition;
    private Vector3 stackBounds = new Vector2(BoundSize, BoundSize);

    Transform lastBlock = null;
    float blockTransition = 0f;
    float secondaryPosition = 0f;

    int stackCount = -1;
    int comboCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(originBlock == null)
        {
            Debug.Log("OriginBlock is Null"); return;
        }

        prevBlockPosition = Vector3.down;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Spawn_Block()
    {

    }
}
