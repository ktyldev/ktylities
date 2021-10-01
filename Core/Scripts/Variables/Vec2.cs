using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Vec2))]
    public class Vec2Editor : SerialVarEditor<Vector2> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/Vec2")]
    public class Vec2 : SerialVar<Vector2>
    {
    }
}
