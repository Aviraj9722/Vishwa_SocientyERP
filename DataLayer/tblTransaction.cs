//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTransaction
    {
        public int ID { get; set; }
        public Nullable<int> ExpensesAcctId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<double> Amount { get; set; }
        public string TransactionType { get; set; }
        public string ModeOfPayment { get; set; }
        public Nullable<System.DateTime> TranDate { get; set; }
        public string Narration { get; set; }
    
        public virtual tblExpens tblExpens { get; set; }
        public virtual tblMember tblMember { get; set; }
    }
}
