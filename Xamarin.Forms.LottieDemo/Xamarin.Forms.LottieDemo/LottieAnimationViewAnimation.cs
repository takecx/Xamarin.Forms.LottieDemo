using System;
using System.Threading;
using System.Threading.Tasks;
using Lottie.Forms;

namespace Xamarin.Forms.LottieDemo
{
	public class LottieAnimationViewAnimation : TriggerAction<AnimationView>
	{
		private bool isFirstRun = true;

		// Properties
		public bool Loop { get; set; } = false;
		public float Speed { get; set; } = 1;
		public long Duration { get; set; } = 0;
		//public bool AutoPlay { get; set; } = false;

		public float From { get; set; } = 0;    // 0 <= From <= 1 && From < To
		public float To { get; set; } = 1;      // 0 <= To <= 1 && From < To
		public int Delay { get; set; } = 0;     // milliseconds

		protected override void Invoke(AnimationView sender)
		{
			AddOnFinishEventHandlerIfNeeded(sender);

			// Set Basic Property
			sender.Speed = Speed;
			sender.Duration = new TimeSpan(Duration);

			if (Delay > 0)
			{
				Task.Run(() =>
				{
					Thread.Sleep(Delay);
					Device.BeginInvokeOnMainThread(() =>
					{
						PlayAnimation(sender);
					});
				});
			}
			else
			{
				PlayAnimation(sender);
			}
		}

		private void AddOnFinishEventHandlerIfNeeded(AnimationView sender)
		{
			if (isFirstRun)
			{
				isFirstRun = false;
				sender.OnFinish += Sender_OnFinish;
			}
		}

		private void PlayAnimation(AnimationView sender)
		{
			//if (AutoPlay)
			//{
			//	sender.Play();
			//	return;
			//}

			// Run Animation
			sender.PlayProgressSegment(From, To);
		}

		void Sender_OnFinish(object sender, EventArgs e)
		{
			if (Loop)
			{
				Invoke(sender);
			}
		}

	}
}
