using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;
		// 문잠금을 담당할 변수
		public static bool door1Open; 

		void Start()
		{
			open = false;
			door1Open = false;
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{
					if(door1Open) // 문열림값이 true일때만 열림 
					{
						//거리확인
						float dist = Vector3.Distance(Player.position, transform.position);
						if (dist < 15)
						{
							if (open == false)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(opening());
								}
							}
							else
							{
								if (open == true)
								{
									if (Input.GetMouseButtonDown(0))
									{
										StartCoroutine(closing());
									}
								}

							}

						}
					}

				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}