using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetAttackAnimation : Action
{
    public SharedAnimationView SelfAnimationView;
    public SharedEnemy Target;
    public override TaskStatus OnUpdate()
    {
        Vector3 targetPosition = new Vector3(Target.Value.transform.position.x, 0, Target.Value.transform.position.z);
        transform.LookAt(targetPosition);

        SelfAnimationView.Value.SetAttack();
        return TaskStatus.Success;
    }
}

