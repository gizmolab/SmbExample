using UnityEngine;
using SmbExample.StateBehaviours;

namespace SmbExample.Logic
{
    [RequireComponent(typeof(Animator))]
    public class StateChangesHandler : MonoBehaviour
    {
        // Name of the state we want to get notifications from
        private const string STATE_NAME = "ExampleState";

        private int _stateNameHash;

        private void Awake()
        {
            _stateNameHash = Animator.StringToHash(STATE_NAME);

            var animator = GetComponent<Animator>();
            var notifiers = animator.GetBehaviours<AnimatorStateChangeNotifications>();
            foreach (var notifier in notifiers)
            {
                notifier.StateEnter += OnStateEnter;
                notifier.StateExit += OnStateExit;
            }
        }

        private void OnStateEnter(int stateNameHash)
        {
            if (_stateNameHash != stateNameHash)
            {
                return;
            }
            OnExampleStateEnter();
        }

        private void OnStateExit(int stateNameHash)
        {
            if (_stateNameHash != stateNameHash)
            {
                return;
            }
            OnExampleStateExit();
        }

        private void OnExampleStateEnter()
        {
            Debug.Log("OnExampleStateEnter");
        }

        private void OnExampleStateExit()
        {
            Debug.Log("OnExampleStateExit");
        }
    }
}