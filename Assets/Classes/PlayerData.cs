using System;

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
		public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int CurrentHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int MaxStrength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int Strength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int MaxArmor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); } 
	}
}
