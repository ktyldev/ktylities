using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(String))]
    public class StringEditor : SerialVarEditor<string> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/String")]
    public class String : SerialVar<string>
    {
    }
}
