using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Ray upRay;
    private RaycastHit upHit;
    private Ray downRay;
    private RaycastHit downHit;

    [SerializeField] private CubeSO cubeNumberSO;
    private int upCubeNumber;
    private int downCubeNumber;
    private int myCubeNumber;
    private bool myCubeIsSelected;

    public int GetMyCubeNumber(CubeScript cube)
    {
        return cube.myCubeNumber;
    }

    public void SetIsSelected(bool value)
    {
        myCubeIsSelected = value;
    }
    public bool GetIsSelected(CubeScript cube)
    {
        return cube.myCubeIsSelected;
    }

    void Start()
    {
        cubeNumberSO.correctPositionUp = false;
        cubeNumberSO.correctPositionDown = false;
        cubeNumberSO.correctOrder = false;
        myCubeNumber = cubeNumberSO.cubeNumber;
        myCubeIsSelected = cubeNumberSO.isSelected;
        upRay = new Ray(transform.position, transform.up);
        downRay = new Ray(transform.position, -1*transform.up);
    }
    void Update()
    {
        upRay.origin = transform.position;
        downRay.origin = transform.position;
        Debug.DrawRay(upRay.origin, upRay.direction * 2, Color.green);
        Debug.DrawRay(downRay.origin, downRay.direction * 2, Color.red);


        //Revisando los rayos hacia arriba
        if (Physics.Raycast(upRay, out upHit, Mathf.Infinity, 1 << 6) || myCubeNumber == 5)
        {

            if (myCubeNumber == 5)
            {
                //Debug.Log("El cubo " + myCubeNumber + " está bien con el de arriba");
                cubeNumberSO.correctPositionUp = true;
            }else if (upHit.rigidbody.GetComponent<CubeScript>().cubeNumberSO != null)
            {
                upCubeNumber = upHit.rigidbody.GetComponent<CubeScript>().cubeNumberSO.cubeNumber;

                if (upCubeNumber == (myCubeNumber + 1))
                {
                    //Debug.Log("El cubo " + myCubeNumber + " está bien con el de arriba");
                    cubeNumberSO.correctPositionUp = true;
              }
            }
            else
            {
                cubeNumberSO.correctPositionUp = false;
            }

        }

        //Revisando los rayos hacia abajo
        if (Physics.Raycast(downRay, out downHit, Mathf.Infinity, 1 << 6) || myCubeNumber == 1)
        {
            //Revisando si son números extremos
            if (myCubeNumber == 1)
            {
                //Debug.Log("El cubo " + myCubeNumber + " está bien con el de abajo");
                cubeNumberSO.correctPositionDown = true;

            }else if (downHit.rigidbody.GetComponent<CubeScript>().cubeNumberSO != null)
            {
                downCubeNumber = downHit.rigidbody.GetComponent<CubeScript>().cubeNumberSO.cubeNumber;

                if (downCubeNumber == myCubeNumber - 1)
                {
                    //Debug.Log("El cubo " + myCubeNumber + "está bien con el de abajo");
                    cubeNumberSO.correctPositionDown = true;
                }

            }
            else
            {
                cubeNumberSO.correctPositionDown = false;
            }
        }


        if(cubeNumberSO.correctPositionDown && cubeNumberSO.correctPositionUp)
        {
            cubeNumberSO.correctOrder = true;
            Debug.Log(cubeNumberSO.cubeNumber + " IS " + cubeNumberSO.correctOrder);
        }
        else
        {
            cubeNumberSO.correctOrder = false;
        }

    }
}
