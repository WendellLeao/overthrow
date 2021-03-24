using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRotate : PlatformController
{
    protected override void Update()
    {
        base.Update();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (isRight)
            {
                if (canRotate == 1)
                {
                    transform.Rotate(new Vector3(0, 0, -70));
                    canRotate = 0;
                }
            }

            if (isLeft)
            {
                if (canRotate == 1)
                {
                    transform.Rotate(new Vector3(0, 0, 70));
                    canRotate = 0;
                }
            }
        }
    }
}
