using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Int))]
    public class IntEditor : SerialVarEditor<int> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/Int")]
    public class Int : SerialVar<int>
    {
    }
}
