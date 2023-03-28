using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
	public interface IPlayerData
	{
		int MaxHealth { get; set; }
		int CurrentHealth { get; set; }
		int MaxStrength { get; set; }
		int Strength { get;set; }
		int MaxArmor { get; set; }
	}

	public struct PlayerData : IPlayerData
	{

	}
}
