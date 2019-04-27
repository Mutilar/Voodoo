
using UnityEngine;
using System.Collections;

public class StudentScriptAnimatorVLecture : MonoBehaviour {
	
	Animator playerGirlAnimator;  //reference to the playerGirlAnimator
	float moveSpeed;   //multipier for the horizontal axis float return
	public bool facingRight = true; 
	bool grounded = false; //to keep track if it can jump or not 
	public Transform groundCheck; //empty game object attached to player to recognize collision with the ground
	float groundRadius = 0.2f; //needed for the Physics2d.Overlap method , how much area of the groundCheck is colliding with the ground
	public LayerMask whatIsGround; //need a separate Layer so ONLY the collision with ground is recognized
	
	
	// Use this for initialization
	void Start () {
		//STUDENT:get Animator of the player
		
		
	}
	
	// FixedUpdate and Update difference: http://unity3d.com/learn/tutorials/modules/beginner/scripting/update-and-fixedupdate
	
	void FixedUpdate () { 
		
		//STUDENT: et moveSpeed from Horizontal Axis
		
		
		
		//leave this
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		//Debug.Log (grounded + "grounded");
		
		
		
		Debug.Log (moveSpeed);
		

		

		
		if(moveSpeed > 0 && !facingRight)
			Flip ();
		else if (moveSpeed < 0 && facingRight)
			Flip ();
		
		
		
	}
	
	
	
	void Flip ()
	{  
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
