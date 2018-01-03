using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using PX.Common;
using PX.Data;
using System.Collections;
using PX.Data.EP;
using PX.Objects.AR;
using PX.Objects.CT;
using PX.Objects.GL;
using PX.Objects.EP;
using PX.Objects.IN;
using PX.Objects.PM;
using PX.SM;
using PX.TM;
using PX.Objects;
using PX.Objects.CR;

namespace PX.Objects.CR
{
	public class CRCaseMaint_Extension : PXGraphExtension<CRCaseMaint>
	{
		public PXAction<CRCase> escalateCase;
		[PXUIField(DisplayName = "Escalate to L2")]
		[PXButton(OnClosingPopup = PXSpecialButtonType.Refresh)]
		protected virtual void EscalateCase()
		{
			CRCase row = Base.CaseCurrent.Current;
			if (row == null) return;

			IPEscalationItem graph = PXGraph.CreateInstance<IPEscalationItem>();

			//graph.Item.Current = graph.Item.Insert();
			graph.Case.Current = row;
			PXRedirectHelper.TryRedirect(graph, PXRedirectHelper.WindowMode.Popup);
		}


		public PXAction<PX.Objects.CR.CRCase> EscalateL3;
		[PXButton(CommitChanges = true)]
		[PXUIField(DisplayName = "Escalate to L3")]
		protected void escalateL3()
		{
			CRCase row = Base.CaseCurrent.Current;
			if (row == null) return;

			IPEscalationItem graph = PXGraph.CreateInstance<IPEscalationItem>();

			//graph.Item.Current = graph.Item.Insert();
			graph.Case.Current = row;
			PXRedirectHelper.TryRedirect(graph, PXRedirectHelper.WindowMode.Popup);
		}
	}
}