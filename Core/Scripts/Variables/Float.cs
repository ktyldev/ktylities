using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Float))]
    public class FloatEditor : SerialVarEditor<float> { }
#endif

    [CreateAssetMenu(menuName = "ktylities/Variables/Float")]
    public class Float : SerialVar<float>
    {
    }
}
