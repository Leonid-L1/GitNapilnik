using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Attack<TObject, TSharedObject> : Action where TObject : Component where TSharedObject : SharedVariable<TObject>
{
    public SharedAnimationView SelfAnimationController;
    public SharedCombatant SelfCombatant;
    public SharedTransform SelfTransform;
    public TSharedObject Target;
    public override TaskStatus OnUpdate()
    {
        SelfAnimationController.Value.SetAttack();
        SelfTransform.Value.LookAt(Target.Value.transform.position);
        Target.Value.GetComponent<CharacterHealthView>().ApplyDamage(SelfCombatant.Value.AttackDamage);

        return TaskStatus.Success;
    }
}
