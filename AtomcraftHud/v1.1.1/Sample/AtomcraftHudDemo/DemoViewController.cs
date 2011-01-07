
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Atomcraft;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace AtomcraftHudDemo
{
	public class DemoViewController : UIViewController
	{
		
		UITableView tvdDemo;
		
		protected ATMHud hud;
		
		protected string[] sectionHeaders, sectionFooters;
		protected string[][] cellCaptions;
		
		protected bool useFixedSize;
		
		int queueCount = 1;
		
		#region Constructors

		// The IntPtr and initWithCoder constructors are required for items that need 
		// to be able to be created from a xib rather than from managed code

		public DemoViewController (IntPtr handle) : base(handle)
		{
			Initialize ();
		}

		[Export("initWithCoder:")]
		public DemoViewController (NSCoder coder) : base(coder)
		{
			Initialize ();
		}

		public DemoViewController ()
		{
			Initialize ();
		}
		
		#endregion
		

		void Initialize ()
		{
				string[] section0 = new [] {"Show with caption only", "Show with caption and activity", "Show with caption and image", "Show activity only", "Play sound on show"};
				string[] section1 = new [] {"Show and auto-hide", "Show, update and auto-hide", "Show progress bar", "Show queued HUD"};
				string[] section2 = new [] {"Accessory top", "Accessory right", "Accessory bottom", "Accessory left"};
				string[] section3 = new [] {"Use fixed size"};
		
				sectionHeaders = new [] {"Basic functions", "Advanced functions", "Accessory positioning", ""};
				sectionFooters = new [] {"Tap the HUD to hide it.", "Tap to hide is disabled.", "", ATMHud.BuildInfo()};
				cellCaptions = new [] {section0, section1, section2, section3};
		}
		
		public override void LoadView ()
		{
			base.LoadView ();
			
			using(var baseView = new UIView(UIScreen.MainScreen.ApplicationFrame))
			{
				tvdDemo = new UITableView(baseView.Bounds, UITableViewStyle.Grouped);
				tvdDemo.Source = new HudTableViewSource(this);
				tvdDemo.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
				
				baseView.AddSubview(tvdDemo);
				
				hud = new ATMHud();
				// Enabling Blocking - causes the sample app to go a bit mental otherwise.
				hud.SetBlockUserInteraction(true);
				hud.UserDidTapHud += (s, e) => 
				{
					hud.Hide();	
				};
				baseView.AddSubview(hud.View);
				
				this.View = baseView;
			}
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			useFixedSize = false;
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}
		
		private class HudTableViewSource : UITableViewSource
		{
			DemoViewController _dvc;
			
			public HudTableViewSource(DemoViewController dvc)
			{
				_dvc = dvc;	
			}
			
			public override string TitleForHeader (UITableView tableView, int section)
			{
				return _dvc.sectionHeaders[section];
			}
			
			public override string TitleForFooter (UITableView tableView, int section)
			{
				return _dvc.sectionFooters[section];
			}
			
			public override int NumberOfSections (UITableView tableView)
			{
				return 4;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				switch (section) {
					case 0:
						return 5;
					case 1:
						return 4;
					case 2:
						return 4;
					case 3:
						return 1;
					default:
						return 0;
				}
			}
			
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var ident = "DefaultCell";
				if (indexPath.Section == 3) {
					ident = "SwitchCell";
				}
				
				var cell = tableView.DequeueReusableCell(ident);
				
				if (cell == null) 
					cell = new UITableViewCell(UITableViewCellStyle.Default, ident);
				
				if (indexPath.Section == 3) {
					
					var fsSwitch = new UISwitch();
					fsSwitch.SizeToFit();	
					fsSwitch.On = _dvc.useFixedSize;
					fsSwitch.ValueChanged += delegate {
						_dvc.useFixedSize = fsSwitch.On;
						if (_dvc.useFixedSize)
							_dvc.hud.SetFixedSize(new SizeF(200, 100));
						else
							_dvc.hud.SetFixedSize(SizeF.Empty);
					};
					cell.AccessoryView = fsSwitch;	
					
					cell.Accessory = UITableViewCellAccessory.None;
					cell.SelectionStyle = UITableViewCellSelectionStyle.None;
				} else {
					cell.AccessoryView = null;
					cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
					cell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
				}
				
				cell.TextLabel.Text = _dvc.cellCaptions[indexPath.Section][indexPath.Row];
				
				return cell;
			}
			
			public override NSIndexPath WillSelectRow (UITableView tableView, NSIndexPath indexPath)
			{
				if (indexPath.Section == 3) {
					return null;
				}
				return indexPath;
			}
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				tableView.DeselectRow(indexPath, true);
	
				switch (indexPath.Section) {
					case 0:
						_dvc.BasicHudActionForRow(indexPath.Row);
						break;
						
					case 1:
						_dvc.AdvancedHudActionForRow(indexPath.Row);
						break;
						
					case 2:
						_dvc.PositioningActionForRow(indexPath.Row);
						break;
				}
			}
			
		}
		
		protected void BasicHudActionForRow(int row)
		{
			switch (row) {
				case 0:
					hud.SetCaption("Just a simple caption.");
					break;
					
				case 1:
					hud.SetCaption("Caption and an activity indicator.");
					hud.SetActivity(true);
					break;
					
				case 2:
					hud.SetCaption("Caption and an image.");
					hud.SetImage(UIImage.FromBundle("19-check"));
					break;
					
				case 3:
					hud.SetActivity(true);
					hud.SetActivityStyle(UIActivityIndicatorViewStyle.WhiteLarge);
					break;
					
				case 4:
					hud.SetCaption("Showing the HUD triggers a sound.");
					hud.ShowSound = NSBundle.MainBundle.PathForResource("pop","wav");
					break;
			}
			hud.Show();
		}
		
		protected void AdvancedHudActionForRow(int row)
		{
			switch (row) {
				case 0:
					hud.SetCaption("This HUD will auto-hide in 2 seconds.");
					hud.BlockTouches = true;
					hud.Show();
					hud.HideAfter(2.0);
					break;
					
				case 1:
					hud.SetCaption("This HUD will update in 2 seconds.");
					hud.BlockTouches = true;
					hud.SetActivity(true);
					hud.Show();
					NSTimer.CreateScheduledTimer(2.0, () => { UpdatedHud(); });
					break;
					
				case 2: 
				{
					float progress = 0.08f;
				
					//NSTimer *timer = [NSTimer scheduledTimerWithTimeInterval:.02 target:self selector:@selector(tick:) userInfo:nil repeats:YES];
					//[[NSRunLoop currentRunLoop] addTimer:timer forMode:NSRunLoopCommonModes];
				
					NSTimer timer = new NSTimer(); 
					timer = NSTimer.CreateRepeatingScheduledTimer(0.02, () => {
						
						progress += 0.01f;
						hud.SetProgress(progress);
						if (progress >= 1) {
							progress = 0;
							timer.Invalidate();
							hud.Hide();
						
							NSTimer.CreateScheduledTimer(0.2, () => { ResetProgress(); });
						}
					});
				
					hud.SetCaption("Performing operation...");
					hud.SetProgress(0.08f);
					hud.BlockTouches = true;
					hud.Show();
					break;
				}
					
				case 3: 
				{
					string[] captions = new [] { "Display #1", "Display #2", "Display #3" };
					// Would love to just use UIImage but breaks when using a "null" image.
					NSArray images = NSArray.FromObjects("", "", UIImage.FromBundle("19-check"));
					NSNumber[] positions = new NSNumber[] { new NSNumber(2), new NSNumber(1), new NSNumber(2) };
					NSNumber[] flags = new NSNumber[] { new NSNumber(false), new NSNumber(true), new NSNumber(false) };
					
					hud.AddToQueue(captions, images, positions, flags);
					hud.StartQueue();
				
					NSTimer.CreateScheduledTimer(2.0, () => { ShowNextDisplayInQueue();	});
					break;
				}
			}
		}
			
		protected void PositioningActionForRow(int row)
		{
			hud.AccessoryPosition = (ATMHudAccessoryPosition) row;
			switch (row) {
				case 0:
					hud.SetCaption("Position: Top");
					hud.SetProgress(0.45f);
					break;
					
				case 1:
					hud.SetCaption("Position: Right");
					hud.SetActivity(true);
					break;
					
				case 2:
					hud.SetCaption("Position: Bottom");
					hud.SetImage(UIImage.FromBundle("11-x"));
					break;
					
				case 3:
					hud.SetCaption("Position: Left");
					hud.SetActivity(true);
					break;
			}
			hud.Show();
		}
		
		[Export("ResetProgress")]
		void ResetProgress()
		{
			hud.SetProgress(0f);	
		}
			
		[Export("UpdateHud")]
		void UpdatedHud()
		{
			hud.SetCaption("And now it will hide.");
			hud.SetActivity(false);
			hud.SetImage(UIImage.FromBundle("19-check"));
			hud.Update();
			hud.HideAfter(2.0);
		}
		
		[Export("ShowNextDisplayInQueue")]
		void ShowNextDisplayInQueue()
		{
			hud.ShowNextInQueue();
			if (queueCount < 3) {
				NSTimer.CreateScheduledTimer(2.0, () => { ShowNextDisplayInQueue(); });
				queueCount++;
			} else {
				queueCount = 1;
				hud.ClearQueue();
			}	
		}
	}
}

