using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif


[System.AttributeUsage(System.AttributeTargets.Field)]
public class ConditionAttribute : PropertyAttribute
{
    public enum ConditionType
    {
        IsTrue ,
        IsGreaterThan ,
        IsEqualTo ,
        IsLessThan ,
    }

    public enum VisibilityType
    {
        Hidden ,
        NotEditable
    }

    public string conditionPropertyName;
    public ConditionType conditionType;
    public VisibilityType visibilityType;
    public float value;

    public System.Func<string , bool> Condition { get ; private set; } 

    /// <summary>
    /// 
    /// </summary>
    /// <param name="conditionPropertyName">Name of the property used by the condition.</param>
    /// <param name="conditionType">Type of the condition.</param>
    /// <param name="visibilityType">The action to performed if the condition is not met.</param>
    /// <param name="value">A float value</param>
    public ConditionAttribute( string conditionPropertyName , ConditionType conditionType , VisibilityType visibilityType = VisibilityType.Hidden , float value = 0f )
    {
        this.conditionPropertyName = conditionPropertyName;
        this.conditionType = conditionType;
        this.visibilityType = visibilityType;
        this.value = value;
    }
}


#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ConditionAttribute))]
public class ConditionAttributeEditor : PropertyDrawer
{
	ConditionAttribute target;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{		
		if( target == null )
			target = attribute as ConditionAttribute;        

        bool result = CheckCondition( property );
        if( target.visibilityType == ConditionAttribute.VisibilityType.NotEditable )
        {
            GUI.enabled = result;
            EditorGUI.PropertyField( position , property , true );
            GUI.enabled = true;
        }
        else
        {
            if( result )
                EditorGUI.PropertyField( position , property , true );
        }
        

	}

    bool CheckCondition( SerializedProperty property )
    {
        SerializedProperty conditionProperty = property.serializedObject.FindProperty( target.conditionPropertyName );

        // If the property is null make the target property visible.
        if( conditionProperty == null )
            return true;
        
        bool result = false;

        SerializedPropertyType conditionPropertyType = conditionProperty.propertyType;

        switch( conditionPropertyType )
        {
            case SerializedPropertyType.Boolean:

                result = conditionProperty.boolValue;
                
                break;
            case SerializedPropertyType.Float:
                
                float conditionPropertyFloatValue = conditionProperty.floatValue;
                float argumentFloatValue = target.value;

                switch( target.conditionType )
                {
                    case ConditionAttribute.ConditionType.IsTrue:
                        result = conditionPropertyFloatValue != 0f;
                        break;
                    case ConditionAttribute.ConditionType.IsGreaterThan:
                        result = conditionPropertyFloatValue > argumentFloatValue;
                        break;
                    case ConditionAttribute.ConditionType.IsEqualTo:
                        result = conditionPropertyFloatValue == argumentFloatValue;
                        break;
                    case ConditionAttribute.ConditionType.IsLessThan:
                        result = conditionPropertyFloatValue < argumentFloatValue;
                        break;
                }
                
                break;
            case SerializedPropertyType.Integer:
                
                int conditionPropertyIntValue = conditionProperty.intValue;
                int argumentIntValue = (int)target.value;

                switch( target.conditionType )
                {
                    case ConditionAttribute.ConditionType.IsTrue:
                        result = conditionPropertyIntValue != 0f;
                        break;
                    case ConditionAttribute.ConditionType.IsGreaterThan:
                        result = conditionPropertyIntValue > argumentIntValue;
                        break;
                    case ConditionAttribute.ConditionType.IsEqualTo:
                        result = conditionPropertyIntValue == argumentIntValue;
                        break;
                    case ConditionAttribute.ConditionType.IsLessThan:
                        result = conditionPropertyIntValue < argumentIntValue;
                        break;
                }
                
                break;
        }        
        
        return result;
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight( property );
    }

    
		
}

#endif


