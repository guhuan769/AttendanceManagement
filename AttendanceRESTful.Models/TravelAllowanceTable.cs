using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.Model
{
    /// 出差补贴明细表
    public class TravelAllowanceTable
    {
        /// id
        private int travelId;
        /// 员工ID
        private int staffId;
        /// 员工姓名
        private string staffName;
        /// 出差日期
        private DateTime travelTime;
        /// 出差天数
        private int travelDaty;
        /// 工作日出差天数
        private int workTravelDay;
        /// 每日补贴金额
        private decimal everyDaySubsidyAmount;
        /// 总补贴金额
        private decimal countSubsiyMoney;
        /// 备注
        private string remarks;
        /// 主管
        private string executiveDirector;
        /// <summary>
        /// /// id
        /// </summary>
        public int TravelId { get => travelId; set => travelId = value; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public int StaffId { get => staffId; set => staffId = value; }
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string StaffName { get => staffName; set => staffName = value; }
        /// <summary>
        /// 出差日期
        /// </summary>
        public DateTime TravelTime { get => travelTime; set => travelTime = value; }
        /// <summary>
        /// 出差天数
        /// </summary>
        public int TravelDaty { get => travelDaty; set => travelDaty = value; }
        /// <summary>
        /// 工作日出差天数
        /// </summary>
        public int WorkTravelDay { get => workTravelDay; set => workTravelDay = value; }
        /// <summary>
        /// 每日补贴金额
        /// </summary>
        public decimal EveryDaySubsidyAmount { get => everyDaySubsidyAmount; set => everyDaySubsidyAmount = value; }
        /// <summary>
        /// 总补贴金额
        /// </summary>
        public decimal CountSubsiyMoney { get => countSubsiyMoney; set => countSubsiyMoney = value; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get => remarks; set => remarks = value; }
        /// <summary>
        /// 主管
        /// </summary>
        public string ExecutiveDirector { get => executiveDirector; set => executiveDirector = value; }
    }
}
