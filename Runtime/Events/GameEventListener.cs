using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ktyl.Ktylities
{
    /// <summary>
    /// A runtime listener for a GameEvent.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _event;
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            _event.Register(this);
        }

        private void OnDisable()
        {
            _event.Unregister(this);
        }

        public void OnEventRaised()
        {
            _response.Invoke();
        }
    }
}
