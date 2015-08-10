using System;
using UnityEngine;


public class PlayerController: MonoBehaviour
{
	public float animSpeed = 1.5f;
	private AnimatorStateInfo currentBaseState;
	//static int RunState = Animator.StringToHash("Base Layer.Run");
	
	
	Animator anim;


	void Start ()
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", h);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		//anim.SetFloat("Direction", v);						// set our animator's float parameter 'Direction' equal to the horizontal input axis
		

		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

		if(currentBaseState.IsTag("Run"))
		{
			if(Input.GetButtonDown("Jump"))
			{
				anim.SetInteger("JumpType", UnityEngine.Random.Range(0,2));
				anim.SetBool("Jump", true);
			}

			if(Input.GetKeyDown (KeyCode.W))
			{
				//anim.SetInteger("JumpType", UnityEngine.Random.Range(0,3));
				anim.SetBool("JumpUp", true);
			}
		}
		
		else if(currentBaseState.IsTag("Jump") || currentBaseState.IsTag("Jumpup"))
		{
			if(!anim.IsInTransition(0))
			{
			anim.SetBool("Jump", false);
			anim.SetBool("JumpUp", false);
			}


		}
		
	
	}
}
