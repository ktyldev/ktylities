using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktylities
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Vec3))]
    public class Vec3Editor : SerialVarEditor<Vector3> { }
#endif

    [CreateAssetMenu(menuName = "ktylities/Variables/Vec3")]
    public class Vec3 : SerialVar<Vector3> { }
}
