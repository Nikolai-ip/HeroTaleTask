using MVC.Model.Entity;

namespace Signals
{
    public class AttackTypeChangedSignal:ISignal
    {
        public AttackType GetAttackType { get; }

        public AttackTypeChangedSignal(AttackType getAttackType)
        {
            GetAttackType = getAttackType;
        }
    }
}