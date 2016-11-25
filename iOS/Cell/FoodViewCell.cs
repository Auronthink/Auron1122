using System;

using Foundation;
using UIKit;

namespace Auron.iOS
{
	public partial class FoodViewCell : UITableViewCell
	{
		protected FoodViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI(Food food)
		{
			lblName.Text = food.Name;
			lblDescription.Text = food.Description;
			imgFood.Image = UIImage.FromFile(food.Img);
		}
	}
}
