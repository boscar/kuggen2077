using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility {

    public const string DASH_MOVEMENT_ID = "dash";
    public const float DEFUALT_DASH_DURATION = 0.066f;
    public const float DEFUALT_DASH_SPEED = 11;
	private AudioClip dashSound = Resources.Load<AudioClip> ("Sounds/Player/Dash");

    private bool hasCooldown = false;
    private float cooldown = 2.0f;

    public float Cooldown {
        get { return cooldown; }
        set { cooldown = value; }
    }

	public void Activate (GameEntity gameEntity, IMovable movable, Vector3 direction) {
        if(hasCooldown) {
            return;
        }
        movable.ActivateEffect(new DashEffect(movable, direction, DEFUALT_DASH_DURATION, DEFUALT_DASH_SPEED), GameEntity.EffectFrequency.FIXED_UPDATE);
        hasCooldown = true;
        TimedEffectFactory.Create(gameEntity, cooldown, () => {
            hasCooldown = false;
        });

		if (gameEntity is IAudible) {
			((IAudible)gameEntity).AudioHandler.PlaySingle (dashSound);
		}
    }

    public class DashEffect : IEffect {

        public string Id { get { return this.ToString(); } }

        private IMovable movable;
        private Vector3 direction;
        private float timer = 0;
        private float duration;
        private float speed;

        public DashEffect(IMovable movable, Vector3 direction, float duration, float speed) {
            this.movable = movable;
            this.direction = direction;
            this.duration = duration;
            this.speed = speed;
            movable.MovementHandler.Move(direction * speed, DASH_MOVEMENT_ID, false);
        }
        public void Activate() {
            //NOOP
        }

        public bool Update(float deltaTime) {
            timer += deltaTime;
            if (timer >= duration) {
                movable.MovementHandler.Move(Vector3.zero, DASH_MOVEMENT_ID, false);
                return true;
            }
            movable.MovementHandler.Move(direction * speed, DASH_MOVEMENT_ID, false);
            return false;
        }
    }

}
