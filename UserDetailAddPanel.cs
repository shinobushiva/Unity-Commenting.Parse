using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;
using System;

public class UserDetailAddPanel : UserAddPanel
{


	public Dropdown age;
	public Dropdown gender;
	public Dropdown occupation;
	public Dropdown residence;
	public Dropdown freaquency;
	public TogglePanel transports;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override void AddUser (ParseDatastoreMaster pdm)
	{
		pdm.Dismiss ();
		
		ParseUser user;

		if (email.text.Length > 0) {
			user = new ParseUser ()
			{
				Username = username.text,
				Password = password.text,
				Email = email.text
			};
		} else {
			user = new ParseUser ()
			{
				Username = username.text,
				Password = password.text,
			};
		}
		user ["age"] = age.options [age.value].text;
		user ["gender"] = gender.options [gender.value].text;
		user ["occupation"] = occupation.options [occupation.value].text;
		user ["residence"] = residence.options [residence.value].text;
		user ["freaquency"] = freaquency.options [freaquency.value].text;
		user ["transports"] = transports.SelectedOptions ();
		
		
		user.SignUpAsync ().ContinueWith (t =>
		{
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				print ("signup failed");
				print (t.Exception);

				pdm.updateLoginStateFlag = true;
			} else {
				// Login was successful.
				print ("signup success");
				pdm.updateLoginStateFlag = true;
			}
		});
	}



}
