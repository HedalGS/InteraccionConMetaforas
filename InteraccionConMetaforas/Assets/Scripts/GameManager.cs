using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject myCube1;
    [SerializeField] GameObject myCube2;
    [SerializeField] GameObject myCube3;
    [SerializeField] GameObject myCube4;
    [SerializeField] GameObject myCube5;

    private CubeScript myCubeScript1;
    private CubeScript myCubeScript2;
    private CubeScript myCubeScript3;   
    private CubeScript myCubeScript4;   
    private CubeScript myCubeScript5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (myCube1.GetComponent<CubeScript>() != null)
        {
            myCubeScript1 = myCube1.transform.GetComponent<CubeScript>();
        }

        if (myCubeScript1.GetIsSelected(myCubeScript1))
        {
            CubeSelected(myCube1);
        }else if (!myCubeScript1.GetIsSelected(myCubeScript1))
        {
            NoCubeSelected(myCube1);
        }
    }

    public void CubeSelected(GameObject cube)
    {
        Renderer renderer = cube.gameObject.GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }

    public void NoCubeSelected(GameObject cube)
    {
        Renderer renderer = cube.gameObject.GetComponent<Renderer>();
        renderer.material.color = Color.red;

    }
}
