using UnityEngine;
using UnityEngine.Experimental.VFX;

#if UNITY_EDITOR
using UnityEditor;

namespace Klak.Wiring
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(VFXKlakInput))]
    public class VFXKlakInputEditor : Editor
    {
        SerializedProperty _onStartEvent;
        SerializedProperty _visualEffect;
        SerializedProperty _parameterName;

        void OnEnable()
        {
            _onStartEvent = serializedObject.FindProperty("_onStartEvent");
            _visualEffect = serializedObject.FindProperty("_visualEffect");
            _parameterName = serializedObject.FindProperty("_parameterName");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_visualEffect);
            EditorGUILayout.PropertyField(_parameterName);
            EditorGUILayout.PropertyField(_onStartEvent);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif


namespace Klak.Wiring
{
    [AddComponentMenu("Klak/Wiring/Input/VFX")]
    public class VFXKlakInput : NodeBase
    {
        #region Node I/O

        [SerializeField]
        string _parameterName = "";
        [SerializeField]
        VisualEffect _visualEffect;
        
        [SerializeField, Outlet]
        FloatEvent _onStartEvent = new FloatEvent();

        #endregion

        #region MonoBehaviour functions

        float _startValue;

        void Start()
        {
            _startValue = _visualEffect.GetFloat(_parameterName);
            _onStartEvent.Invoke(_startValue);
        }

        #endregion
    }
}
