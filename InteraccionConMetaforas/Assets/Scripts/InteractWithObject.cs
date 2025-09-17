using UnityEngine;

public class InteractWithObject : MonoBehaviour
{
    private Touch myTouch;
    Vector3 touchRayPosition = Vector3.zero;
    private RaycastHit rayHit;
    private CubeScript cubeSelected;
    void Start()
    {
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            //Se guarda el primer touch
            myTouch = Input.GetTouch(0);

            //Se guardan los valores del primer touch
            float touchPositionX = myTouch.position.x;
            float touchPositionY = myTouch.position.y;
            //Se asignan los valores del primer touch dentro del vector de la posición del rayo
            touchRayPosition.x = touchPositionX;
            touchRayPosition.y = touchPositionY;

            //Se lanza el rayo desde la posición del primer touch en la pantalla
            Ray ray = Camera.main.ScreenPointToRay(touchRayPosition);
            //Se dibuja el rayo del primer touch. Visible sólo en el editor
            Debug.DrawRay(ray.origin, ray.direction*100, Color.yellow);



            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity, 1 << 6))
            {
                //Debug.Log("Raycast con objeto de layer: "+rayHit.rigidbody.gameObject.layer);

                if (rayHit.transform.GetComponent<CubeScript>() != null)
                {
                    //Tocamos un Cube con componente CubeScript
                    Vector3 touchPosition = GetTouchWorldToPosition();
                    cubeSelected = rayHit.transform.GetComponent<CubeScript>();
                    touchPosition.y = cubeSelected.transform.position.y;
                    TouchInPhase();
                }
            }
            else
            {
                Debug.Log("Touch!");
            }

        }
       
    }

    public Vector3 GetTouchWorldToPosition()
    {
        Vector3 touchPositionScreen = Input.GetTouch(0).position;
     
        Vector3 touchPositionWorld = Camera.main.ScreenToWorldPoint(
            new Vector3 (touchPositionScreen.x, 
            Mathf.Abs(transform.position.y - Camera.main.transform.position.y), touchPositionScreen.z));

        return touchPositionWorld;
    }

    public void TouchInPhase()
    {
        switch (myTouch.phase)
        {
            case TouchPhase.Began:
                //Condicionales del impacto del rayo que lanzamos
                cubeSelected.SetIsSelected(true);
                break;
            case TouchPhase.Moved:
            case TouchPhase.Stationary:

                break;

            case TouchPhase.Ended:
                cubeSelected.SetIsSelected(false);
                break;
        }
    }
}
