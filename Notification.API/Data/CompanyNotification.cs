//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notification.API.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyNotification
    {
        public int Id { get; set; }
        public System.DateTime Notification_Date { get; set; }
        public int Company_Id { get; set; }
        public System.DateTime CreatedDttm { get; set; }
        public System.DateTime ModifiedDttm { get; set; }
    
        public virtual CompanyInfo CompanyInfo { get; set; }
    }
}
