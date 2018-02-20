using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameEntity, IMovable, IAttacker, IAttackable, IObservable<Player>, IAudible {

	public int PLAYER_ID = 0;

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
	public AudioHandler AudioHandler { get; protected set; }

    public Rigidbody Rigidbody { get; set; }
	public AudioSource AudioSource { get; set; }

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
			CallObservers ();
        }
    }

	private List<IObserver<Player>> observers = new List<IObserver<Player>> ();
	public List<IObserver<Player>> Observers { get { return observers; } private set { observers = value; } }

    void Awake () {
		InitHandlers();
        DashAbility = new DashAbility();
        AttackActions.Add(ATTACK_PRIMARY, new PlayerDefaultAttack(this));
        InitStats();
        InitEffects();
    }

    new void Start() {
        base.Start();
        InitComponents();
		CallObservers ();
    }

    protected new void FixedUpdate() {
        base.FixedUpdate();
        if (MovementHandler != null) {
            MovementHandler.Update(Time.fixedDeltaTime);
        }
    }

    private void InitStats() {
		HighScoreManager.AddPlayer (PLAYER_ID);
        HitPoints = 100;
        CurrentHitPoints = 100;
        MovementSpeed = new FloatStat(DEFAULT_PLAYER_MOVEMENT_SPEED);
    }

    private void InitHandlers() {
        MovementHandler = new MovementHandler(this);
        RecieveAttackHandler = new RecieveAttackHandler(this);
        AttackHandler = new AttackHandler(this);
		AudioHandler = new AudioHandler (this);

    }

    private void InitEffects() {
        Renderer renderer = GetBodyRenderer();
        if (renderer != null) {
            RecieveAttackHandler.RecieveAttackCreators.Add(new TemporaryColorChangeEffectCreator(this, renderer, Color.white));
        }
        AttackHandler.AttackCreators.Add(new ReduceMovementSpeedEffectCreator(this, 0.35f, 0.5f));
        AttackHandler.AttackCreators.Add(new SpawnParticlesEffectCreator(this, "particles/VfxFireSparks", 0.25f, new Vector3(0.3f, 1.7f, 1.1f)));

        RecieveAttackHandler.RecieveAttackSoundEffects.Add((new SoundEffectCreator(this,
			Resources.Load<AudioClip>("Sounds/Player/Damaged1"),
			Resources.Load<AudioClip>("Sounds/Player/Damaged2"),
			Resources.Load<AudioClip>("Sounds/Player/Damaged3"),
			Resources.Load<AudioClip>("Sounds/Player/Damaged4"),
			Resources.Load<AudioClip>("Sounds/Player/Damaged5")
		)));

		RecieveAttackHandler.DeathSoundEffects.Add (new SoundEffectCreator (this, Resources.Load<AudioClip> ("Sounds/Player/Death")));
    }

    private void InitComponents() {
		Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null) {
            throw new KuggenException("Rigidbody can not be null for " + this);
        }

		AudioSource = GetComponent<AudioSource>();
		if (AudioSource == null) {
			throw new KuggenException("AudioSource can not be null for " + this);
		}
    }

	public void setAttackAction(string key, AttackAction attack){
		AttackActions [key] = attack;
		CallObservers ();
	}

	public void IncrementScore(int score){
		HighScoreManager.IncrementPlayerScore (PLAYER_ID, score);
		CallObservers ();
	}

	public int GetScore(){
		return HighScoreManager.GetPlayerScore (PLAYER_ID);
	}

	// IObservable implementation
	public void AddObserver(IObserver<Player> obs){
		Observers.Add (obs);
	}

	public void RemoveObserver(IObserver<Player> obs) {
		Observers.Remove (obs);
	}

	public void CallObservers() {
		foreach (IObserver<Player> obs in Observers) {
			obs.OnUpdate(this);
		}	
	}
}
