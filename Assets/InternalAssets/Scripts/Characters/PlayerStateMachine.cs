using UnityEngine;

namespace InternalAssets.Scripts.Player
{
    public class PlayerStateMachine : StateMachineBehaviour
    {
        private bool _canWalk;

        public bool CanWalk => _canWalk;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
            if (stateInfo.IsTag("Barrel"))
            {
                _canWalk = true;
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo,
            int layerIndex)
        {
        }
    }
}