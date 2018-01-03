using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffectCreator : RecieveAttackEffectCreator {

    private IMovable movable;

    public KnockbackEffectCreator(IAttackable attackable, IMovable movable) : base(attackable) {
        this.movable = movable;
    }

    public override bool Activate(Attack attack) {
        float duration = 0.08f;
        Attackable.ActivateEffect(new KnockbackEffect(movable, GetMovementVector(attack), duration), GameEntity.EffectFrequency.FIXED_UPDATE);
        return true;
    }

    private Vector3 GetMovementVector(Attack attack) {
        Vector3 attackPos = new Vector3(attack.Position.x, 0, attack.Position.z);
        Vector3 targetPos = new Vector3(Attackable.Transform.position.x, 0, Attackable.Transform.position.z);
        return (targetPos - attackPos).normalized * attack.Force;
    }

    public class KnockbackEffect : IEffect {
        public string Id { get { return this.ToString() + this.GetHashCode(); } }

        private IMovable movable;
        private Vector3 movementVector;
        private float timer = 0;
        private float duration;
        private DecelerateInterpolator interpolator;

        public KnockbackEffect(IMovable movable, Vector3 movementVector, float duration) {
            this.movementVector = movementVector;
            this.duration = duration;
            this.movable = movable;
            interpolator = new DecelerateInterpolator();
        }

        public void Activate() {
            movable.MovementHandler.Move(movementVector, Id, false);
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            if (timer >= duration) {
                movable.MovementHandler.Move(Vector3.zero, Id, false);
                return true;
            }
            Vector3 newMovementVector = (1 - interpolator.GetInterpolation(timer / duration)) * movementVector;
            movable.MovementHandler.Move(newMovementVector, Id, false);
            return false;
        }

    }

}
