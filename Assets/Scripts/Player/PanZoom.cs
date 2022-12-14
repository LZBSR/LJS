using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
  public float zoomOutMin = 1;
 public float zoomOutMax = 8;
   private Touch touch;
    // Update is called once per frame
    void Update()
    {
        //Pan Function
       
       if (Input.GetMouseButtonDown(0))
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            { if(touch.phase == TouchPhase.Moved)
                {

                    touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
          
        }
       //Zoom Function
     if (Input.touchCount == 2)
        {
            //zoom function
            
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            
        }
   
        if (Input.GetMouseButton(0))
        {
            
            if (touch.phase == TouchPhase.Ended) {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;
            }
                
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

  void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
  
    
}