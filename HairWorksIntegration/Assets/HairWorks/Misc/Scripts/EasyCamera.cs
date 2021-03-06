using UnityEngine;
using System.Collections;

public class EasyCamera : MonoBehaviour {

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public float speed = 0.01f;
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -90F;
    public float maximumY =  90F;

    float rotationY = 0F;

    bool onFocused = false;
    //Underwater underWater = null;
  
    void LateUpdate()
    {
       
        if ( Input.GetMouseButton(1))
        {
            Screen.lockCursor = true;

            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }

            float move_ = Input.GetAxis("Vertical");
            if (move_ > 0)
            {
                transform.position += transform.forward * speed;
            }
            else if (move_ < 0)
            {
                transform.position -= transform.forward * speed;
            }

            move_ = Input.GetAxis("Horizontal");
            if (move_ > 0)
            {
                transform.position += transform.right * speed;
            }
            else if (move_ < 0)
            {
                transform.position -= transform.right * speed;
            }
        }
        else
            Screen.lockCursor = false;
    }

    void Start()
    { 
    }
    void OnEnable()
    {
     
       
    }
    void OnDisable()
    {
        
        Screen.lockCursor = false;
    }

    void Update()
    {
        //if (transform.position.y <= 2)
        //{
        //    underWater.enabled = true;
        //}
        //else
        //{
        //    underWater.enabled = false;
        //}
    }

   
}
