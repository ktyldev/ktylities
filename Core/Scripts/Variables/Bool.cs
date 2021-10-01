using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Bool))]
    public class BoolEditor : SerialVarEditor<bool> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/Bool")]
    public class Bool : SerialVar<bool> { }
}
