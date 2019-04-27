using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Demo : MonoBehaviour {
	bool[] keys = {false,false,false,false};
	int counter = 350;
	int subCount = 0;


	public bool cameraSnap = false;

	bool part2 = false;
	bool part3 = false;
	bool part4 = false;
	bool part5 = false;
	bool part6 = false;
	bool part7 = false;

	bool part7part1 = true;
	//strats
	//tower, rush
	//boss fights

	bool part8 = false;
	bool part9 = false;
	bool part10 = false;
	bool part11 = false;
	bool part12 = false;

	bool part13 = false;
	bool part14 = false;
	bool part15 = false;
	bool part16 = false;

	public GameObject explosionFriend;
	public GameObject red2;
	public GameObject red1;
	public GameObject pink0;


	public GameObject uiOverlay;
	public GameObject farmer;
	public GameObject soldier;
	public GameObject priest;
	public GameObject witchdoctor;

	public GameObject title;
	public Sprite control;
	public Sprite minion;
	public Sprite strategies;
	public Sprite bosses;

	public GameObject fade;

	bool fading;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (counter < 400) {
						counter++;
				} else {
						GetComponent<Text> ().text = "The Camera:\nLook around with WASD";

						bool completed = true;
						if (Input.GetKey (KeyCode.W))
								keys [0] = true;
						if (Input.GetKey (KeyCode.A))
								keys [1] = true;
						if (Input.GetKey (KeyCode.S))
								keys [2] = true;
						if (Input.GetKey (KeyCode.D))
								keys [3] = true;
						for (int i = 0; i < 4; i++)
								if (!keys [i])
										completed = false;
						if (completed)
						{
							GetComponent<Text> ().text = "Minions:\nClick on the icon to spawn a unit";
							uiOverlay.SetActive(true);
							farmer.SetActive(true);
							soldier.SetActive(false);
							priest.SetActive(false);
							witchdoctor.SetActive(false);
							if (GameObject.FindGameObjectWithTag("friendly")) part2 = true;


			
							if (part2)
							{	
								GetComponent<Text> ().text = "Minions:\nClick to set a waypoint for them to go to";
								

							if (part3)
								{
						title.GetComponent<Image>().sprite = minion;
						title.GetComponent<RectTransform>().sizeDelta = new Vector2(257f, 46f);
						GetComponent<Text> ().text = "Farmers:\nFast, but have no attack\nBasically cannonfodder";
									if (part4) 
									{
										GetComponent<Text> ().text = "Soldiers:\nFast, with a simple sword\nFor hacking and slashing";
							soldier.SetActive(true);			
							if (part5) 
							{
								GetComponent<Text> ().text = "Priests:\nMagical, but defenseless\nYour staple ranged unit";
								priest.SetActive(true);
								if (part6)
								{
									GetComponent<Text> ().text = "Witchdoctors:\nSlow, but magical and carry a small dagger\nWell rounded elites";
									witchdoctor.SetActive(true);
									if (part7)
									{
										title.GetComponent<Image>().sprite = strategies;
										title.GetComponent<RectTransform>().sizeDelta = new Vector2(307f, 68f);
										if (part7part1) 
										{
											GameObject[] people = GameObject.FindGameObjectsWithTag("friendly");
											for (int i = 0; i < people.Length; i++) people[i].tag = "magicDead";

										}
										part7part1 = false;
										GetComponent<Text> ().text = "Towering:\nFocuses firepower of minions vertically";
										if (part8)
										{
											GetComponent<Text> ().text = "Towering:\nSpawn some mages and have them go to the same spot";

											if (part9)
											{
												GetComponent<Text> ().text = "Towering:\nHere come some enemies!\n Lets see how your mages handle them";
												if (part10)
												{
													GetComponent<Text> ().text = "Rushing:\nUse melee units in a tower, then charge forward to gain ground";

													if (part10)
													{
														GetComponent<Text> ().text = "Rushing:\nHere come some enemies, flood them!";
														if (part11)
														{
															GetComponent<Text> ().text = "Now for something a little different...";
															title.GetComponent<Image>().sprite = bosses;
															title.GetComponent<RectTransform>().sizeDelta = new Vector2(188,44);

															cameraSnap = true;
															uiOverlay.SetActive(false);
															if (part12)
															{
																GetComponent<Text> ().text = "Controls:\nUse WASD to move\nDouble tap a direction to go faster";
																if (part13)
																{
																	GetComponent<Text> ().text = "Controls:\nPress Space to shoot";
																	if (part14)
																	{
																		for (int i = 0; i < 5; i++) Instantiate (pink0, new Vector2(4f + Random.value, 1f), this.transform.rotation);		
																		GetComponent<Text> ().text = "Here come some enemies, kill them!";
																		if (part15)
																		{
																			//Destroy (title);
																			GetComponent<Text> ().text = "Looks like you got the hang of it!\nGood luck and have fun!";
																			if (part16)
																			{
																				Application.LoadLevel("Menu");
																			fading = true;
																			}

																			part16 = true;
																			counter = 0;
																		}



																		part15 = true;
																		counter = 0;
																	}



																	part14 = true;
																	counter = 0;
																}

																part13 = true;
																counter = 0;
															}
															else
															{
																GameObject[] people = GameObject.FindGameObjectsWithTag("friendly");
																for (int i = 0; i < people.Length; i++) people[i].tag = "magicDead";
																GameObject[] peopledddd= GameObject.FindGameObjectsWithTag("enemy");
																for (int i = 0; i < peopledddd.Length; i++) Destroy (peopledddd[i]);
															}
															part12 = true;
														}													
														else
														{
															GameObject[] peoplezd = GameObject.FindGameObjectsWithTag("friendly");
															for (int i = 0; i < peoplezd.Length; i++) if (peoplezd[i].GetComponent<Movement>().shooting == true || peoplezd[i].GetComponent<Movement>().meele == false)
															{ 
																Instantiate (explosionFriend, new Vector2(peoplezd[i].transform.position.x, peoplezd[i].transform.position.y), this.transform.rotation);					
																Destroy (peoplezd[i]);
																Instantiate (red1, new Vector2(peoplezd[i].transform.position.x, peoplezd[i].transform.position.y), this.transform.rotation);		
																
															}
														GameObject[] peoplezzd = GameObject.FindGameObjectsWithTag("friendly");
														for (int i = 0; i < (int)(peoplezzd.Length / 2); i++) Instantiate (pink0, new Vector2(4f + Random.value, 1f + Random.value / 2 ), this.transform.rotation);		
														}
													}


													part11 = true;
													counter = 0;

												}

										
												if (!part10)
												{
													bool otherThanMages = false;
												GameObject[] peoplez = GameObject.FindGameObjectsWithTag("friendly");
												for (int i = 0; i < peoplez.Length; i++) if (peoplez[i].GetComponent<Movement>().shooting != true)
												{
													Instantiate (explosionFriend, new Vector2(peoplez[i].transform.position.x, peoplez[i].transform.position.y), this.transform.rotation);					
													Destroy (peoplez[i]);
													otherThanMages = true;
													//Instantiate (red2, new Vector2(peoplez[i].transform.position.x, peoplez[i].transform.position.y), this.transform.rotation);		

												}
												if (otherThanMages) GetComponent<Text> ().text += "\nMeele units don't work well in towers";
											
												GameObject[] peopled = GameObject.FindGameObjectsWithTag("friendly");
													for (int i = 0; i < peopled.Length; i++) Instantiate (pink0, new Vector2(4f + Random.value,2f + Random.value), this.transform.rotation);		
												subCount++;
												if (subCount == 3)
												{
													part10 = true;
													counter = 0;
												}
												}

											}






											GameObject[] peoples = GameObject.FindGameObjectsWithTag("friendly");
											for (int i = 0; i < peoples.Length; i++) if (peoples[i].transform.position.y > .8f){ part9 = true; counter = 350; }
										
										
										}


										part8 = true;
										counter = 200;

									}

									part7 = true;
									counter = 0;

								}
								part6 = true;
								counter = 0;

							}
							part5 = true;
							counter = 0;
									}


									
						part4 = true;
						counter = 0;
								}

								if (Input.GetMouseButton(0) && part3 == false)
								{
									part3 = true;
									counter = 200;
						
								}

							


							}




						



						}


				}
	}
}
