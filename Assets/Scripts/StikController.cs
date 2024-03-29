using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StikController : MonoBehaviour
{
   [SerializeField] KeyCode keyOne;
   [SerializeField] KeyCode keyTwo;
   [SerializeField] Vector3 moveDirection;
	
    private void FixedUpdate() 
    {
	if (Input.GetKey(keyOne))
	{
		GetComponent<Rigidbody>().velocity += moveDirection;
	}
	if (Input.GetKey(keyTwo))
	{
		GetComponent<Rigidbody>().velocity -= moveDirection;
	}
	if (Input.GetKey(KeyCode.R))
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    }

	private void OnTriggerEnter(Collider other)
   {
		  if(this.CompareTag("Player") && other.CompareTag("Finish"))
		  {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		  }
		  if(this.CompareTag("Cube") && other.CompareTag("Cube"))
		  {
				foreach(BUTTon button in FindObjectsOfType<BUTTon>())
				{
					button.canPush = false;
				}
		  }
   }
   private void OnTriggerExit(Collider other)
   {
		  if(this.CompareTag("Cube") && other.CompareTag("Cube"))
		  {
				foreach(BUTTon button in FindObjectsOfType<BUTTon>())
				{
					button.canPush = true;
				}
		  }
   }
}
