using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(Vec3))]
    public class Vec3Editor : SerialVarEditor<Vector3> { }
#endif

    [CreateAssetMenu(menuName = "ktools/Variables/Vec3")]
    public class Vec3 : SerialVar<Vector3> { }
}
