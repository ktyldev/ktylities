using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(String))]
    public class StringEditor : SerialVarEditor<string> { }
#endif

    [CreateAssetMenu(menuName = "ktylities/Variables/String")]
    public class String : SerialVar<string>
    {
    }
}
