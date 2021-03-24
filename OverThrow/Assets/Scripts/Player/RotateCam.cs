using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    public bool lockMouse = true;
    public static float sensibility = 1.0f;

    private float mouseX, mouseY;

    public static int canTurnCam = 0;

    void Update()
    {
        if (GameManager.isStart)
        {
            mouseX += Input.GetAxis("Mouse X");
            mouseY -= Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(mouseY * sensibility, mouseX * sensibility, 0);

            if (Cubes.isShake)
            {
                GetComponent<Animator>().SetTrigger("isShake");
            }

            /*if (Rout.canTurnUp != 0)
            {
                this.transform.eulerAngles = new Vector3(0,0,0);
            }

            else if (Rout.canTurnDown != 0)
            {
                this.transform.eulerAngles = new Vector3(0, 90, 0);
            }

            else if (Rout.canTurnRight != 0)
            {
                this.transform.eulerAngles = new Vector3(0, -90, 0);
            }

            else if (Rout.canTurnLeft != 0)
            {
                this.transform.eulerAngles = new Vector3(0, 180, 0);
            }*/

            /*if(MoveCamera.canTurnCam != 0)
            {
                /*if(mouseX < 0)
                {
                    mouseX = (90 * 1);
                }

                if(mouseX > 0)
                {
                    mouseX = (-90 * 1);
                }
            }
            else
            {
                mouseX += Input.GetAxis("Mouse X");
                mouseY -= Input.GetAxis("Mouse Y");

                transform.eulerAngles = new Vector3(mouseY * sensibility, mouseX * sensibility, 0);
            }*/
        }
    }
}
