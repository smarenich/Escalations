using System;
using PX.Data;
using PX.Objects.CR;
using PX.Objects.CR.MassProcess;
using PX.TM;
using PX.Data.EP;

namespace PX.Objects.CR
{
	public class CRCaseExtension : PXCacheExtension<CRCase>
	{
		#region UsrSecondaryOwnerID
		public abstract class usrSecondaryOwnerID : IBqlField
		{
		}
		[PXDBGuid()]
		[PXOwnerSelector()]
		[PXChildUpdatable(AutoRefresh = true, TextField = "AcctName", ShowHint = false)]
		[PXUIField(DisplayName = "Secondary Owner")]
		[PXMassUpdatableField]
		[PXMassMergableField]
		public virtual Guid? UsrSecondaryOwnerID { get; set; }
		#endregion

		#region UsrEscalateReason
		public abstract class usrEscalateReason : IBqlField { }
		protected String _UsrEscalateReason;
		[PXDBString(1, IsFixed = true)]
		[EscalateAttribute()]
		[PXUIField(DisplayName = "Escalation", Enabled = false)]
		[PXMassUpdatableField]
		[PXDefault(PersistingCheck = PXPersistingCheck.Nothing)]
		public virtual String UsrEscalateReason
		{
			get
			{
				return this._UsrEscalateReason;
			}
			set
			{
				this._UsrEscalateReason = value;
			}
		}
		#endregion

		#region UseCommentEscalateReason
		public abstract class usrCommentEscalateReason : IBqlField { }
		protected String _UsrCommentEscalateReason;
		[PXString(1, IsFixed = true)]
		[PXDefault("A", PersistingCheck = PXPersistingCheck.Nothing)]
		[EscalateAttribute()]
		[PXUIField(DisplayName = "Escalation")]
		public virtual String UsrCommentEscalateReason
		{
			get
			{
				return this._UsrCommentEscalateReason;
			}
			set
			{
				this._UsrCommentEscalateReason = value;
			}
		}
		#endregion

		#region CommentEscalateBody
		public abstract class commentescalateBody : PX.Data.IBqlField
		{
		}
		protected String _CommentEscalateBody;
		[PXString(IsUnicode = true)]
		[PXUIField(DisplayName = "Comment")]
		public virtual String CommentEscalateBody
		{
			get
			{
				return this._CommentEscalateBody;
			}
			set
			{
				this._CommentEscalateBody = value;
			}
		}
		#endregion

		#region UsrEscalateAttribute
		[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
		public sealed class EscalateAttribute : PXStringListAttribute
		{
		}
		#endregion

		#region UsrDateEscalatedToL2
		public abstract class usrDateEscalatedToL2 : IBqlField { }
		[PXDBDate(PreserveTime = true, DisplayMask = "g")]
		[PXUIField(DisplayName = "Escalated to L2 on", Enabled = false)]
		public virtual DateTime? UsrDateEscalatedToL2 { get; set; }
		#endregion

		#region UsrDateEscalatedToL3
		public abstract class usrDateEscalatedToL3 : IBqlField { }
		[PXDBDate(PreserveTime = true, DisplayMask = "g")]
		[PXUIField(DisplayName = "Escalated to L3 on", Enabled = false)]
		public virtual DateTime? UsrDateEscalatedToL3 { get; set; }
		#endregion

	}
}
