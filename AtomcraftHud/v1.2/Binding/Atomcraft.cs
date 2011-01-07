using System;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace Atomcraft
{	
	//@interface ATMHud : UIViewController {
	[BaseType (typeof (UIViewController), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] { typeof (ATMHudDelegate)})]
	interface ATMHud {
		
		#region Delegates
		
		[Export ("delegate"), NullAllowed, New]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate"), New]
		ATMHudDelegate Delegate { get; set; }
		
		#endregion
		
		#region Properties
		
		//@property (nonatomic, assign) CGFloat margin;
		[Export ("margin", ArgumentSemantic.Assign)]
		float Margin { get; set; }

		//@property (nonatomic, assign) CGFloat padding;
		[Export ("padding", ArgumentSemantic.Assign)]
		float Padding { get; set; }
		
		//@property (nonatomic, assign) CGFloat alpha;
		[Export ("alpha", ArgumentSemantic.Assign)]
		float Alpha { get; set; }

		//@property (nonatomic, assign) CGFloat appearScaleFactor;
		[Export ("appearScaleFactor", ArgumentSemantic.Assign)]
		float AppearScaleFactor { get; set; }

		//@property (nonatomic, assign) CGFloat disappearScaleFactor;
		[Export ("disappearScaleFactor", ArgumentSemantic.Assign)]
		float DisappearScaleFactor { get; set; }

		//@property (nonatomic, assign) CGFloat progressBorderRadius;
		[Export ("progressBorderRadius", ArgumentSemantic.Assign)]
		float ProgressBorderRadius { get; set; }

		//@property (nonatomic, assign) CGFloat progressBorderWidth;
		[Export ("progressBorderWidth", ArgumentSemantic.Assign)]
		float ProgressBorderWidth { get; set; }

		//@property (nonatomic, assign) CGFloat progressBarRadius;
		[Export ("progressBarRadius", ArgumentSemantic.Assign)]
		float ProgressBarRadius { get; set; }

		//@property (nonatomic, assign) CGFloat progressBarInset;
		[Export ("progressBarInset", ArgumentSemantic.Assign)]
		float ProgressBarInset { get; set; }
		
		
		//@property (nonatomic, assign) CGPoint center;
		[Export ("center", ArgumentSemantic.Assign)]
		System.Drawing.PointF Center { get; set; }
		
		
		//@property (nonatomic, assign) BOOL shadowEnabled;
		[Export ("shadowEnabled", ArgumentSemantic.Assign)]
		bool ShadowEnabled { get; set; }

		//@property (nonatomic, assign) BOOL blockTouches;
		[Export ("blockTouches", ArgumentSemantic.Assign)]
		bool BlockTouches { get; set; }
		
		//@property (nonatomic, assign) BOOL blockUserInteraction;
		[Export ("blockUserInteraction", ArgumentSemantic.Assign)]
		bool BlockUserInteraction { get; set; }
		
		
		//@property (nonatomic, retain) NSString *showSound;
		[Export ("showSound", ArgumentSemantic.Retain)]
		string ShowSound { get; set; }
		
		//@property (nonatomic, retain) NSString *updateSound;
		[Export ("updateSound", ArgumentSemantic.Retain)]
		string UpdateSound { get; set; }
		
		//@property (nonatomic, retain) NSString *hideSound;
		[Export ("hideSound", ArgumentSemantic.Retain)]
		string HideSound { get; set; }
		
		
		//@property (nonatomic, assign) ATMHudAccessoryPosition accessoryPosition;
		[Export ("accessoryPosition", ArgumentSemantic.Assign)]
		ATMHudAccessoryPosition AccessoryPosition { get; set; }
		
		// Private
		
		//@property (nonatomic, retain) ATMHudView *__view;
		[Export ("__view", ArgumentSemantic.Retain)]
		ATMHudView HudView { get; set; }
		
		//@property (nonatomic, retain) ATMSoundFX *sound;
		[Export ("sound", ArgumentSemantic.Retain)]
		ATMSoundFX Sound { get; set; }
		
		//@property (nonatomic, retain) NSMutableArray *displayQueue;
		[Export ("displayQueue", ArgumentSemantic.Retain)]
		NSArray DisplayQueue { get; set; }
		
		//@property (nonatomic, assign) NSMutableArray queuePosition;
		[Export ("queuePosition", ArgumentSemantic.Assign)]
		int QueuePosition { get; set; }
		
		#endregion
		
		//- (id)initWithDelegate:(id)hudDelegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (ATMHudDelegate hudDelegate);
		
		#region Methods
		
		//+ (NSString *)buildInfo;
		[Static, Export ("buildInfo")]
		string BuildInfo();
		
		//- (void)setCaption:(NSString *)caption;
		[Export ("setCaption:")]
		void SetCaption (string caption);
		
		//- (void)setImage:(UIImage *)image;
		[Export ("setImage:")]
		void SetImage (UIImage image);
		
		//- (void)setActivity:(BOOL)flag;
		[Export ("setActivity:")]
		void SetActivity (bool flag);
		
		//- (void)setActivityStyle:(UIActivityIndicatorViewStyle)style;
		[Export ("setActivityStyle:")]
		void SetActivityStyle (UIActivityIndicatorViewStyle style);
		
		//- (void)setFixedSize:(CGSize)size;
		[Export ("setFixedSize:")]
		void SetFixedSize (System.Drawing.SizeF size);
		
		//- (void)setProgress:(CGFloat)progress;
		[Export ("setProgress:")]
		void SetProgress (float size);
		
		//- (void)addQueueItem:(ATMHudQueueItem *)item;
		[Export ("addQueueItem:")]
		void AddToQueue(ATMHudQueueItem item);
		
		//- (void)addQueueItems:(NSArray *)items;
		[Export ("addQueueItems:")]
		void AddToQueue(ATMHudQueueItem[] items);
	
		//- (void)clearQueue;
		[Export ("clearQueue")]
		void ClearQueue();
		
		//- (void)startQueue;
		[Export ("startQueue")]
		void StartQueue();
		
		//- (void)showNextInQueue;
		[Export ("showNextInQueue")]
		void ShowNextInQueue();
		
		//- (void)showQueueAtIndex:(NSInteger)index;
		[Export ("showQueueAtIndex:")]
		void ShowQueueAtIndex(int index);
		
		
		//- (void)show;
		[Export ("show")]
		void Show();
		
		//- (void)update;
		[Export ("update")]
		void Update();
		
		//- (void)hide;
		[Export ("hide")]
		void Hide();
	
		//- (void)hideAfter:(NSTimeInterval)delay;
		[Export ("hideAfter:")]
		void HideAfter(double delay);
		
		
		//- (void)playSound:(NSString *)soundPath;
		[Export ("playSound:")]
		void PlaySound(string soundPath);
		
		#endregion
	}
	
	
	[Model]
	[BaseType (typeof (NSObject))]
	interface ATMHudDelegate {
		
		//- (void)userDidTapHud:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("UserTappedHud")]
		[Export ("userDidTapHud:")]
		void UserDidTapHud (ATMHud _hud);
		
		//- (void)hudWillAppear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillAppear")]
		[Export ("hudWillAppear:")]
		void HudWillAppear (ATMHud _hud);
		
		//- (void)hudDidAppear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidAppear")]
		[Export ("hudDidAppear:")]
		void HudDidAppear (ATMHud _hud);
		
		//- (void)hudWillUpdate:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillUpdate")]
		[Export ("hudWillUpdate:")]
		void HudWillUpdate (ATMHud _hud);
		
		//- (void)hudDidUpdate:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidUpdate")]
		[Export ("hudDidUpdate:")]
		void HudDidUpdate (ATMHud _hud);
		
		//- (void)hudWillDisappear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudWillDisappear")]
		[Export ("hudWillDisappear:")]
		void HudWillDisappear (ATMHud _hud);
		
		//- (void)hudDidDisappear:(ATMHud *)_hud;
		[Abstract]//, DelegateName ("HudDidDisappear")]
		[Export ("hudDidDisappear:")]
		void HudDidDisappear (ATMHud _hud);
	}
	
	[BaseType (typeof (NSObject))]
	interface ATMHudView { }
	
	[BaseType (typeof (NSObject))]
	interface ATMSoundFX { }
	
	[BaseType (typeof (NSObject))]
	interface ATMHudQueueItem
	{
	
		//@property (nonatomic, retain) NSString *caption;
		[Export ("caption", ArgumentSemantic.Retain)]
		string Caption { get; set; }
		
		//@property (nonatomic, retain) UIImage *image;
		[Export ("image", ArgumentSemantic.Retain)]
		UIImage Image { get; set; }
		
		//@property (nonatomic, assign) BOOL showActivity;
		[Export ("showActivity", ArgumentSemantic.Assign)]
		bool ShowActivity { get; set; }
		
		//@property (nonatomic, assign) ATMHudAccessoryPosition accessoryPosition;
		[Export ("accessoryPosition", ArgumentSemantic.Assign)]
		ATMHudAccessoryPosition AccessoryPosition { get; set; }
		
		//@property (nonatomic, assign) UIActivityIndicatorViewStyle activityStyle;
		[Export ("activityStyle", ArgumentSemantic.Assign)]
		UIActivityIndicatorViewStyle ActivityStyle { get; set; }
	}
}

