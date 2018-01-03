using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameEntity, IMovable, IAttacker, IAttackable, IObservable<Player> {

    public const float DEFAULT_PLAYER_MOVEMENT_SPEED = 7;
    public const float DEFAULT_PLAYER_MOVEMENT_FLOATINESS = 8f;

    public const string ATTACK_PRIMARY = "attack_primary";

    protected float movementSpeed = DEFAULT_PLAYER_MOVEMENT_SPEED;

    public FloatStat MovementSpeed { get; protected set;  }

    protected float movementFloatiness = DEFAULT_PLAYER_MOVEMENT_FLOATINESS;

    public float MovementFloatiness {
        get { return movementFloatiness; }
        set { movementFloatiness = value; }
    }

    public MovementHandler MovementHandler { get; set; }
    public RecieveAttackHandler RecieveAttackHandler { get; protected set; }
    public AttackHandler AttackHandler { get; protected set; }

    public Rigidbody Rigidbody { get; set; }

    public Transform Transform {
        get { return transform; }
    }

    public DashAbility DashAbility { get; private set; }

    private Dictionary<string, AttackAction> attackActions = new Dictionary<string, AttackAction>();

    public Dictionary<string, AttackAction> AttackActions {
        get { return attackActions;  }
    }

    protected int hitPoints;
    public int HitPoints {
        get { return hitPoints; }
        set {
            hitPoints = value;
            if (currentHitPoints > hitPoints) {
                currentHitPoints = hitPoints;
            }
        }
    }

    protected int currentHitPoints;
    public int CurrentHitPoints {
        get { return currentHitPoints; }
        set {
            currentHitPoints = value;
            if (currentHitPoints > HitPoints) {
                currentHitPoints = HitPoints;
            }
			callObservers ();
        }
    }

	protected int score;
	public int Score {
		get { return score; }
		set {
			score = value;
			callObservers ();
		}
	}

	private List<IObserver<Player>> observers = new List<IObserver<Player>> ();

    void Awake () {
        DashAbility = new DashAbility();
        AttackActions.Add(ATTACK_PRIMARY, new PlayerDefaultAttack(this));
        InitStats();
        InitHandlers();
        InitEffects();
    }

    void Start() {
        InitComponents();
		callObservers ();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        if (MovementHandler != null) {
            MovementHandler.Update(Time.fixedDeltaTime);
        }
    }

    private void InitStats() {
        HitPoints = 100;
        CurrentHitPoints = 100;
		Score = 0;
        MovementSpeed = new FloatStat(DEFAULT_PLAYER_MOVEMENT_SPEED);
    }

    private void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
        AttackHandler = new AttackHandler(this);
    }

    private void InitEffects() {
        RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, Color.white));
        AttackHandler.AttackCreators.Add(new ReduceMovementSpeedEffectCreator(this, 0.25f, 0.25f, 1f));
    }

    private void InitComponents() {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }
    }

	// IObservable implementation
	public void addObserver(IObserver<Player> obs){
		observers.Add (obs);
	}

	public void removeObserver(IObserver<Player> obs) {
		observers.Remove (obs);
	}

	public void callObservers() {
		foreach (IObserver<Player> obs in observers) {
			obs.onUpdate(this);
		}	
	}
}
