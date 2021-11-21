using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Bool))]
    public class BoolEditor : SerialVarEditor<bool> { }
#endif

    [CreateAssetMenu(menuName = "ktylities/Variables/Bool")]
    public class Bool : SerialVar<bool> { }
}
