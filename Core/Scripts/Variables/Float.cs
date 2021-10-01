using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Float))]
    public class FloatEditor : SerialVarEditor<float> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/Float")]
    public class Float : SerialVar<float>
    {
    }
}
