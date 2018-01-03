using System;
using PX.Data;
using System.Collections;
using PX.Objects.EP;
using PX.SM;

namespace PX.Objects.CR
{
	[Serializable]
	public class IPEscalationItem : PXGraph<IPEscalationItem>
	{
        public const string CRActivityTypeL2ESC = "L2ESC";
        public const string CRCaseResolutionInEscalation = "ES";

        [Serializable]
        public class EscalationItem : IBqlTable
        {
            #region Subject
            public abstract class subject : IBqlField { }
            [PXString]
            [PXDefault]
            public virtual string Subject { get; set; }
            #endregion
            #region Description
            public abstract class description : IBqlField { }
            [PXString]
            [PXDefault]
            public virtual string Description { get; set; }
            #endregion
        }

        #region Selects
        public PXSelect<CRCase> Case;
        public PXSelect<CRSetup> Setup;
        public PXFilter<EscalationItem> Item;
        #endregion

        #region Actions
        public PXAction<EscalationItem> EscalateCase;
        [PXUIField(DisplayName = "Escalate Case")]
        [PXButton]
        public virtual IEnumerable escalateCase(PXAdapter adapter)
        {
            var graph = PXGraph.CreateInstance<CRCaseMaint>();
            var crCase = Case.Current;

            graph.Case.Current = crCase;

            crCase.Status = CRCaseStatusesAttribute._OPEN;
            crCase.Resolution = CRCaseResolutionInEscalation; // Use local constant instead of modifying PX.Objects

            var caseExtension = PXCache<CRCase>.GetExtension<CRCaseExtension>(crCase);
            caseExtension.UsrSecondaryOwnerID = Case.Current.OwnerID;
            crCase.OwnerID = null;

            var setup = (CRSetup)Setup.Select();
            var setupExt = PXCache<CRSetup>.GetExtension<CRSetupExt>(setup);

            crCase.WorkgroupID = setupExt.UsrEscalationWorkgroupID;

            caseExtension.UsrDateEscalatedToL2 = DateTime.Now;
            graph.Case.Update(crCase);

            var caseAdapter = new PXAdapter(graph.Case.View);
            caseAdapter.Menu = CRActivityTypeL2ESC;
            try
            {
                graph.Activities.NewActivity(caseAdapter);
            }
            catch (PXRedirectRequiredException redirect)
            {
                var activityGraph = (CRActivityMaint)redirect.Graph;
                var currentActivity = activityGraph.Activities.Current;
                currentActivity.Subject = Item.Current.Subject;
                currentActivity.Body = Item.Current.Description;
                activityGraph.Activities.Update(currentActivity);
                activityGraph.Actions.PressSave();
            }

            graph.Actions.PressSave();

            return adapter.Get();
        }

        public PXAction<EscalationItem> Close;
        [PXUIField(DisplayName = "Close")]
        [PXButton]
        public virtual IEnumerable close(PXAdapter adapter)
        {
            return adapter.Get();
        }
        #endregion

        #region Events
        protected virtual void EscalationItem_RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            if (e.Row == null)
                return;

            var setup = (CRSetup)Setup.Select();
			var setupExt = PXCache<CRSetup>.GetExtension<CRSetupExt>(setup);
			if (setupExt != null)
			{
				var template = (Notification)PXSelect<Notification,
												Where<Notification.notificationID,
													Equal<Required<Notification.notificationID>>>>
													.Select(this, setupExt.UsrEscalationNotificationMapID);

				EscalationItem row = (EscalationItem)e.Row;
				row.Subject = template != null ? template.Subject : "Escalation";
				row.Description = template != null ? template.Body : "Escalation";
			}
        }
        #endregion
    }
}