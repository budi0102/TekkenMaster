using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	/// <summary>
	/// MoveSet Class
	/// Contains multiple Commands and information related to those commands to make as a Move.
	/// </summary>
	[DataContract]
	public class MoveSet
	{
		#region Enums
		[Flags]
		public enum HitPos
		{
			None = 0,
			High = 1,
			Mid = 1 << 1,
			SpecialMid = 1 << 2,
			Low = 1 << 3,
			Grounded = 1 << 4,
			ThrowGrab = 1 << 5,
			Unblockable = 1 << 6,
			Homing = 1 << 7,
			Screw = 1 << 8
		}
		[Flags]
		public enum PositionProp
		{
			Unknown = 0,
			Stand = 1,
			Crouch = 1 << 1,
			BackTurned = 1 << 2,
			Jump = 1 << 3,
			SideStepLeft = 1 << 4,
			SideStepRight = 1 << 5,
			FaceUpFeetNearest = 1 << 6,
			FaceUpHeadNearest = 1 << 7,
			FaceDownFeetNearest = 1 << 8,
			FaceDownHeadNearest = 1 << 9
		}
		[Flags]
		public enum CrushProp
		{
			None = 0,
			[Display(Description = "Evade Enemy's High Attack", Name = "High Crush", ShortName = "HighCrush")]
			HighCrushEvadeHigh,
			[Display(Description = "Evade Enemy's Mid Attack", Name = "Mid Crush", ShortName = "MidCrush")]
			MidCrushEvadeMid,
			[Display(Description = "Evade Enemy's Low Attack", Name = "Low Crush", ShortName = "LowCrush")]
			LowCrushEvadeLow,
			[Display(Description = "Evade Enemy's Attack by Stepping Back first", Name = "Step Back", ShortName = "StepBack")]
			StepBack,
			[Display(Description = "Evade Enemy's High Attack", Name = "High Crush", ShortName = "HighCrush")]
			PowerCrush,

			Invicible

		}
		#endregion

		[DataMember]
		public MultiLocaleString Name { get; set; }
		[DataMember]
		public List<Command> Commands { get; set; }
		[DataMember]
		public List<HitPos> HitPositions { get; set; }
		[IgnoreDataMember]
		public CrushProp CrushProperty { get { return CrushProperties.LastOrDefault(); } }
		/// <summary>
		/// Player Property on the Move
		/// </summary>
		[DataMember]
		public List<CrushProp> CrushProperties { get; set; }
		[IgnoreDataMember]
		public PositionProp PositionPropertiy { get { return PositionProperties.LastOrDefault(); } }
		/// <summary>
		/// Player Property after Move is completed
		/// </summary>
		[DataMember]
		public List<PositionProp> PositionProperties { get; set; }
		[DataMember]
		public PositionProp EnemyPositionProperty { get; set; }
		[IgnoreDataMember]
		public int Damage { get { return (Damages != null) ? Damages.Sum() : 0; } }
		[DataMember]
		public List<int> Damages { get; set; }
		[DataMember]
		public List<int> ActiveFrames { get; set; }
		[DataMember]
		public int? FastestFrame { get; set; }
		[DataMember]
		public int? FrameOnBlock { get; set; }
		[DataMember]
		public int? FrameOnHit { get; set; }
		[DataMember]
		public int? FrameOnCounterHit { get; set; }
		[DataMember]
		public string Note { get; set; }

		#region Constructor
		public MoveSet()
		{
			Name = new MultiLocaleString();
			Commands = new List<TekkenLibrary.Command>();
			HitPositions = new List<HitPos>();
			CrushProperties = new List<CrushProp>();
			PositionProperties = new List<PositionProp>();
			EnemyPositionProperty = PositionProp.Stand;
			Damages = new List<int>();
			ActiveFrames = new List<int>();
			FastestFrame = null;
			FrameOnBlock = null;
			FrameOnHit = null;
			FrameOnCounterHit = null;
			Note = null;
		}
		#endregion

		#region Public Methods
		public void AddMove(Command move, HitPos hitPosition, int damage,
			CrushProp crushProperty = CrushProp.None,
			PositionProp positionProperty = PositionProp.Stand,
			PositionProp enemyPositionProperty = PositionProp.Stand)
		{
			Commands.Add(move);
			HitPositions.Add(hitPosition);
			Damages.Add(damage);
			CrushProperties.Add(crushProperty);
			PositionProperties.Add(positionProperty);
		}
		#endregion
	}
}
