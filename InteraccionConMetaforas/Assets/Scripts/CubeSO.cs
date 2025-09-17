using UnityEngine;

[CreateAssetMenu(fileName = "CubeSO", menuName = "ScriptableObject/CubeSO")]
public class CubeSO : ScriptableObject
{
    public int cubeNumber;
    public bool correctPositionUp;
    public bool correctPositionDown;
    public bool correctOrder;
    public bool isSelected;

}
