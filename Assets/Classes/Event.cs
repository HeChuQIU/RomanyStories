using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
	public abstract class Event<TEvnetArgs> where TEvnetArgs : IEventArgs
	{
		public string Id { get; }

		public void Subscribe(Action<TEvnetArgs> callBack) => this.callBack += callBack;

		public void Unsubscribe(Action<TEvnetArgs> callBack) => this.callBack -= callBack;

		protected Action<TEvnetArgs> callBack;
	}

	public interface IEventArgs
	{
		public object Sender { get; }
	}
}
