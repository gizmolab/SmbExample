using System;
using UnityEngine;

namespace SmbExample.StateBehaviours
{

public class AnimatorStateChangeNotifications : StateMachineBehaviour
{
    public event Action<int> StateEnter;

    public event Action<int> StateExit;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateEnter.Invoke(stateInfo.shortNameHash);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit?.Invoke(stateInfo.shortNameHash);
    }
}


}
