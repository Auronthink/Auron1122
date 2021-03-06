﻿using System;

using Foundation;
using UIKit;

namespace Auron.iOS
{
	public partial class UserViewCell : UITableViewCell
	{
		protected UserViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI (User user)
		{
			lblName.Text = user.Name;
			lblDescription.Text = user.Description;
			//imgFood.Image = UIImage.FromFile(user.Img);
		}
	}
}
