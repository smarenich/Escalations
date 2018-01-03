using System;
using PX.Data;
using PX.Objects.CR;
using PX.Objects.CS;
using PX.SM;
using PX.TM;

namespace PX.Objects.CR
{
	public class CRSetupExt : PXCacheExtension<CRSetup>
	{
        #region UsrEscalationNotificationMapID
        public abstract class usrEscalationNotificationMapID : IBqlField { }
        [PXDBInt]
        [PXUIField(DisplayName = "Notification Template")]
        [PXSelector(typeof(Search<Notification.notificationID>), DescriptionField = typeof(Notification.name))]
        public virtual int? UsrEscalationNotificationMapID { get; set; }
        #endregion
        #region UsrEscalationWorkgroupID
        public abstract class usrEscalationWorkgroupID : IBqlField { }
        [PXDBInt]
        [PXUIField(DisplayName = "Workgroup ID")]
        [PXSelector(typeof(Search<EPCompanyTree.workGroupID>), DescriptionField = typeof(EPCompanyTree.description))]
        public virtual int? UsrEscalationWorkgroupID { get; set; }
        #endregion
    }
}
