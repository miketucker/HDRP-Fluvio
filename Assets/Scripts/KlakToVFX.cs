using UnityEngine;
using UnityEngine.Experimental.VFX;

#if UNITY_EDITOR
using UnityEditor;

namespace Klak.Wiring
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(KlakTOVFX))]
    public class KlakTOVFXEditor : Editor
    {
        SerializedProperty _visualEffect;
        SerializedProperty _parameterName;

        void OnEnable()
        {
            _visualEffect = serializedObject.FindProperty("_visualEffect");
            _parameterName = serializedObject.FindProperty("_parameterName");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_visualEffect);
            EditorGUILayout.PropertyField(_parameterName);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif


namespace Klak.Wiring
{
    [AddComponentMenu("Klak/Wiring/Output/VFX")]
    public class KlakTOVFX : NodeBase
    {
        #region Node I/O

        [SerializeField]
        string _parameterName = "";
        [SerializeField]
        VisualEffect _visualEffect;
        #endregion

        #region MonoBehaviour functions

        float _lastValue;



        [Inlet]
        public float floatInput {
            set {
                if (!enabled || _visualEffect == null) return;
                _lastValue = value;
                _visualEffect.SetFloat(_parameterName, _lastValue);
                // Debug.Log("floatIn: " + value);
            }
        }

        #endregion
    }
}
