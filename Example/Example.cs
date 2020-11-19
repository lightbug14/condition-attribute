using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField]
    bool filterByTag = false;

    
    [Condition( "filterByTag" , ConditionAttribute.ConditionType.IsTrue , ConditionAttribute.VisibilityType.Hidden )]    
    [SerializeField]
    string filterTag = "SomeTag";

    [SerializeField]
    bool useLayerMask = false;

    [Condition( "useLayerMask" , ConditionAttribute.ConditionType.IsTrue , ConditionAttribute.VisibilityType.NotEditable )]
    [SerializeField]
    LayerMask someLayerMask = 0;

    public int speed = 0;

    [Condition( "speed" , ConditionAttribute.ConditionType.IsGreaterThan , ConditionAttribute.VisibilityType.Hidden , 5f )]
    public bool showHighSpeedWarning = true;
    

}








