using UnityEngine;

public class Example : MonoBehaviour
{
    public enum Reference
    {
        World ,
        Local , 
        External
    }

    [SerializeField]
    Reference referenceMode = Reference.World;

    [Condition( "referenceMode" , ConditionAttribute.ConditionType.IsEqualTo , ConditionAttribute.VisibilityType.Hidden , (int)Reference.External )]
    [SerializeField]
    Transform externalReference = null;

    [SerializeField]
    bool filterByTag = false;
    
    [Condition( "filterByTag" , ConditionAttribute.ConditionType.IsTrue , ConditionAttribute.VisibilityType.Hidden )]    
    [SerializeField]
    string filterTag = "SomeTag";

    [SerializeField]
    bool activeLayerMask = false;

    [Condition( "activeLayerMask" , ConditionAttribute.ConditionType.IsTrue , ConditionAttribute.VisibilityType.NotEditable )]
    [SerializeField]
    LayerMask someLayerMask = 0;

    [SerializeField]
    float speed = 0;

    [Condition( "speed" , ConditionAttribute.ConditionType.IsGreaterThan , ConditionAttribute.VisibilityType.Hidden , 5f )]
    public bool showHighSpeedWarning = true;


    

}







