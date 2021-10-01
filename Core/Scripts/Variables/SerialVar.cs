using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
    #region Editor
#if UNITY_EDITOR
    using UnityEditor;

    public abstract class SerialVarEditor<T> : Editor
    {
        private SerialVar<T> _t;

        protected virtual void OnEnable()
        {
            _t = target as SerialVar<T>;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.LabelField("Current Value", _t.Value.ToString());
            EditorGUI.EndDisabledGroup();
        }
    }

    public partial class SerialVar<T>
    {
        public T EDITOR_InitialValue
        {
            get => _initialValue;
            set => _initialValue = value;
        }
    }
#endif
    #endregion

    /// <summary>
    /// A runtime-independent instance of a variable of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    public abstract partial class SerialVar<T> : ScriptableObject
    {
        /// <summary>
        /// The current value of the variable.
        /// </summary>
        public T Value
        {
            get => Application.isPlaying ? _value : _initialValue;
            set
            {
                if (_readOnly)
                {
                    Debug.LogError($"{name}: tried to write to read-only variable", this);
                    return;
                }

                _value = value;
            }
        }
        private T _value;

        [SerializeField] private T _initialValue;
        [SerializeField] private bool _readOnly;

        public static implicit operator T(SerialVar<T> t) => t.Value;

        private void OnValidate()
        {
            _value = _initialValue;
        }

        private void OnEnable()
        {
            _value = _initialValue;
        }

        public override string ToString() => Value.ToString();
    }
}
