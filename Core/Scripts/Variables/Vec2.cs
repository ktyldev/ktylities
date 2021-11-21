using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Vec2))]
    public class Vec2Editor : SerialVarEditor<Vector2> { }
#endif

    [CreateAssetMenu(menuName = "ktylities/Variables/Vec2")]
    public class Vec2 : SerialVar<Vector2>
    {
    }
}
