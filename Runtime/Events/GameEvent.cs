using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ktyl.Ktools
{
    #region Editor
#if UNITY_EDITOR
    using UnityEditor;

    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        private GameEvent _event;

        private void OnEnable()
        {
            _event = target as GameEvent;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Raise"))
            {
                _event.Raise();
            }

            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            if (GUILayout.Button("Ping Next Listener"))
            {
                _event.EDITOR_PingNextListener();
            }
            EditorGUI.EndDisabledGroup();
        }
    }

    public partial class GameEvent
    {
        private int _EDITOR_pingIdx;

        public void EDITOR_PingNextListener()
        {
            Debug.Log($"{name}: ping listener {_EDITOR_pingIdx + 1}/{_listeners.Count}", this);

            EditorGUIUtility.PingObject(_listeners[_EDITOR_pingIdx++]);
            _EDITOR_pingIdx %= _listeners.Count;
        }
    }
#endif
    #endregion

    [CreateAssetMenu(menuName = "ktools/Events/Game Event")]
    public partial class GameEvent : ScriptableObject
    {
        [SerializeField] private bool _logRaised;

        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();
        private readonly List<GameEventListener> _listenersBuffer = new List<GameEventListener>();

        public virtual void Raise()
        {
            if (_logRaised)
            {
                Debug.Log($"raised {this}", this);
            }

            // copy listeners into buffer, as the response may modify the original list
            _listenersBuffer.Clear();
            _listenersBuffer.AddRange(_listeners);

            for (int i = 0; i < _listenersBuffer.Count; i++)
            {
                _listenersBuffer[i].OnEventRaised();
            }
        }

        public void Register(GameEventListener listener)
        {
            if (_listeners.Contains(listener))
            {
                Debug.LogError($"{listener} already registered");
                return;
            }

            _listeners.Add(listener);
        }

        public void Unregister(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                Debug.LogError($"{listener} not already registered");
                return;
            }

            _listeners.Remove(listener);
        }
    }
}
