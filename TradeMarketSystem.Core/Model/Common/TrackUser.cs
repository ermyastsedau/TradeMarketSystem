using System;


namespace TradeMarketSystem.Core.Model.Common
{
    public class TrackUserSettingOperation
    {
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class Operations : TrackUserSettingOperation
    {
        public string Status { get; set; }
        public string Remark { get; set; }
        public bool IsVoid { get; set; }
        public string VoidBy { get; set; }
        public DateTime? VoidTime { get; set; }
        public bool IsOnlineApproved { get; set; }
        public string OnlineApprovedBy { get; set; }
        public DateTime? OnlineApprovedTime { get; set; }
        public bool IsOnlineTransferred { get; set; }
        public string IsOnlineTransferredBy { get; set; }
        public DateTime? OnlineTransferredTime { get; set; }
        //added
        public bool IsSendForApproval { get; set; }
        public string OrgBranchName { get; set; }
        public string SendForApprovalBy { get; set; }
        public DateTime? SendForApprovalTime { get; set; }
    }
    public class OperationWithSecondValidation : Operations
    {
        public bool IsSecondOnlineApproved { get; set; }
        public string SecondOnlineApprovedBy { get; set; }
        public DateTime? SecondOnlineApprovedTime { get; set; }

        public bool IsSecondSendForApproval { get; set; }
        public string SecondSendForApprovalBy { get; set; }
        public DateTime? SecondSendForApprovalTime { get; set; }
    }

    public class OperationWithFourValidation : OperationWithSecondValidation
    {
        public bool IsThirdOnlineApproved { get; set; }
        public string ThirdOnlineApprovedBy { get; set; }
        public DateTime? ThirdOnlineApprovedTime { get; set; }

        public bool IsFourthSendForApproval { get; set; }
        public string FourthSendForApprovalBy { get; set; }
        public DateTime? FourthSendForApprovalTime { get; set; }
    }
    public class TrackUserOperation : TrackUserSettingOperation
    {
        public string OrgBranchName { get; set; }
    }
}
