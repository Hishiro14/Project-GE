using Production.Plugins.RyanScriptableObjects.SOReferences.BoolReference;
using Production.Plugins.RyanScriptableObjects.SOReferences.FloatReference;
using Production.Scripts.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Production.Scripts.Components
{
	public class PlayerController : MonoBehaviour
	{
		private InputEntity _inputEntity;
		[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
		[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
		[Range(0, 1f)] [SerializeField] public float m_MovementSmoothing = .05f;	// How much to smooth out the movement
		[SerializeField] private bool m_AirControl = false;	
		
		[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
		[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
		[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings
		[SerializeField] private Collider2D m_CrouchDisableCollider;
		[SerializeField] private Transform WallCheckR;
		[SerializeField] private Transform WallCheckL;
		[SerializeField] private LayerMask m_WhatisWall;
		
		public BoolReference DoubleJumpReference;
		public BoolReference DashActiveReference;
		public BoolReference WallJumpActiveReference;
		public FloatReference DashForce;
		private bool canDash;
		float DashCoolDown =1f;
		private float dashTime;
		
		public FloatReference InvertHorizontalAxis;
		
		[SerializeField] private bool canDoubleJump;
		
		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		[SerializeField] public bool m_Grounded;            // Whether or not the player is grounded.
		const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
		public Rigidbody2D m_Rigidbody2D;
		public bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private Vector3 m_Velocity = Vector3.zero;


		private float k_WallRadiusL = 0.1f;
		private float k_WallRadiusR = 0.1f;

		[SerializeField] private bool isTouchingWall;
		[SerializeField] private Transform wall;
		Transform lastWall;
		
		[Header("Events")]
		[Space]

		public UnityEvent OnLandEvent;

		[System.Serializable]
		public class BoolEvent : UnityEvent<bool> { }

		public BoolEvent OnCrouchEvent;
		private bool m_wasCrouching = false;

		//Sound
		public SoundComponent sound;

		private void Awake()
		{
			sound = GetComponent<SoundComponent>();
			_inputEntity = GetComponent<InputEntity>();
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
			canDash = true;
			if (OnLandEvent == null)
				OnLandEvent = new UnityEvent();

			if (OnCrouchEvent == null)
				OnCrouchEvent = new BoolEvent();
		}

		private void FixedUpdate()
		{
			bool wasGrounded = m_Grounded;
			m_Grounded = false;
			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					m_Grounded = true;
					if (!wasGrounded)
					{
						OnLandEvent.Invoke();
					}
				}
			}
			isTouchingWall = false;
			Collider2D[] sideCollidersL = Physics2D.OverlapCircleAll(WallCheckL.position, k_WallRadiusL, m_WhatisWall);
			for (int i = 0; i < sideCollidersL.Length; i++)
			{
				if (sideCollidersL[i].gameObject != gameObject)
				{
					wall = sideCollidersL[i].gameObject.transform;
					isTouchingWall = true;
					
				}
				
			}
			Collider2D[] sideCollidersR = Physics2D.OverlapCircleAll(WallCheckR.position, k_WallRadiusR, m_WhatisWall);
			for (int i = 0; i < sideCollidersR.Length; i++)
			{
				if (sideCollidersR[i].gameObject != gameObject)
				{
					wall = sideCollidersR[i].gameObject.transform;
					isTouchingWall = true;
					
				}
			}
		
			if (canDash == false)
			{
				dashTime += Time.deltaTime;
				if (dashTime > DashCoolDown)
				{
					dashTime = 0;
					//canDash = true;
				}
			}
		}
		public void Move(float move, bool crouch, bool jump, bool dash, float dashX, float dashY)
		{
			// If crouching, check to see if the character can stand up
			if (!crouch)
			{
				// If the character has a ceiling preventing them from standing up, keep them crouching
				if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
				{
					crouch = true;
				}
			}

			//only control the player if grounded or airControl is turned on
			if (m_Grounded || m_AirControl)
			{
				
				// If crouching
				if (crouch)
				{
					if (!m_wasCrouching)
					{
						m_wasCrouching = true;
						OnCrouchEvent.Invoke(true);
					}

					// Reduce the speed by the crouchSpeed multiplier
					move *= m_CrouchSpeed;

					// Disable one of the colliders when crouching
					if (m_CrouchDisableCollider != null)
						m_CrouchDisableCollider.enabled = false;
				} else
				{
					// Enable the collider when not crouching
					if (m_CrouchDisableCollider != null)
						m_CrouchDisableCollider.enabled = true;

					if (m_wasCrouching)
					{
						m_wasCrouching = false;
						OnCrouchEvent.Invoke(false);
					}
				}

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(InvertHorizontalAxis.Value*move * 10f, m_Rigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

//				// If the input is moving the player right and the player is facing left...
//				if (move > 0 && !m_FacingRight)
//				{
//					// ... flip the player.
//					Flip();
//				}
//				// Otherwise if the input is moving the player left and the player is facing right...
//				else if (move < 0 && m_FacingRight)
//				{
//					// ... flip the player.
//					Flip();
//				}
			}

			if (WallJumpActiveReference.Value)
			{
				if (!m_Grounded && isTouchingWall && jump ||!m_Grounded && isTouchingWall && jump)
				{
					if (lastWall == wall)
					{
						Debug.Log("Meme mur bitch" + lastWall.name);
					}
					if (lastWall == null && wall == null)
					{
						Debug.Log("Murs sont null");
					}
					Debug.Log("Wall " + wall + " lastWall " + lastWall);
					if (wall != null && wall != lastWall || wall != null && lastWall == null)
					{
						
						canDash = true;
						if (wall.position.x < transform.position.x)
						{
							//Debug.Log("Le mur est a gauche");
							m_Rigidbody2D.velocity = Vector2.zero;
							Vector2 dir = Vector2.right + Vector2.up;
							dir.Normalize();
							m_Rigidbody2D.AddForce(dir*m_JumpForce);
							isTouchingWall = false;
							sound.Play("JumpFx");
							lastWall = wall;
						}
						else
						{
							m_Rigidbody2D.velocity = Vector2.zero;
							Vector2 dir = Vector2.left + Vector2.up;
							dir.Normalize();
							m_Rigidbody2D.AddForce(dir*m_JumpForce);
							isTouchingWall = false;
							sound.Play("JumpFx");
							lastWall = wall;
						}
					}
				}
			}
			if (jump && dash)
			{
				if (m_Grounded && DoubleJumpReference.Value == false)
				{
					sound.Play("JumpFx");
					// Add a vertical force to the player.
					m_Grounded = false;
					m_Rigidbody2D.velocity = Vector2.zero;
					m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
				}

				if (!m_Grounded && DoubleJumpReference.Value && canDoubleJump)
				{
					Debug.Log("DoubleJump");
					sound.Play("JumpFx");
					m_Grounded = false;
					canDoubleJump = false;
					m_Rigidbody2D.velocity = Vector2.zero;
					m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce*0.75f));
				}
			}
			if (m_Grounded && jump && DoubleJumpReference.Value==false && !dash)
			{
				Debug.Log("Jump");
				sound.Play("JumpFx");
				// Add a vertical force to the player.
				m_Grounded = false;
				m_Rigidbody2D.velocity = Vector2.zero;
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			}
			if (DoubleJumpReference.Value && !dash)
			{
				if (!m_Grounded && jump && canDoubleJump)
				{
					Debug.Log("DoubleJump");
					sound.Play("JumpFx");
					m_Grounded = false;
					canDoubleJump = false;
					m_Rigidbody2D.velocity = Vector2.zero;
					m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
				}
				if (m_Grounded && jump)
				{
					Debug.Log("Jump");
					sound.Play("JumpFx");
					m_Rigidbody2D.velocity = Vector2.zero;
					m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
					m_Grounded = false;
				}
			}
			if (!jump && canDash && dash && DashActiveReference.Value)
			{
				Debug.Log("Dash");
				sound.Play("DashFx");
				m_Rigidbody2D.velocity = Vector2.zero;
				Vector2 dashDir = new Vector2(dashX, dashY);
				dashDir.Normalize();
				if(dashDir == Vector2.zero) dashDir = Vector2.up;
				m_Rigidbody2D.AddForce(InvertHorizontalAxis.Value*dashDir*DashForce.Value, ForceMode2D.Force);
				canDash = false;
			}

		}

		

		public void Land()
		{
		    wall = null;
		    lastWall = null;
			dashTime = 0;
			canDoubleJump = true;
			canDash = true;
			m_AirControl = true;
			gameObject.GetComponent<ArrowComponent>().UnactiveArrow();
		}
//		public void Flip()
//		{
//			// Switch the way the player is labelled as facing.
//			m_FacingRight = !m_FacingRight;
//
//			// Multiply the player's x local scale by -1.
//			Vector3 theScale = transform.localScale;
//			theScale.x *= -1;
//			transform.localScale = theScale;
//		}

		public void ResetBoolOnDead()
		{
			DoubleJumpReference.Value = false;
		}
		
	}
}
