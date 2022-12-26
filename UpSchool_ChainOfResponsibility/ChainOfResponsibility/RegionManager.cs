using UpSchool_ChainOfResponsibility.DAL.Entities;
using UpSchool_ChainOfResponsibility.DAL;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager :Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 250000)
            {

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge müdürü - Nazlı Siyah";
                bankProcess.Description = "Müşteriye talep olmuş olduğu ödemesi Bölge müdürü tarafından gerçekleştirildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;
                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                
                //db ye kaydetme işlemi
                //Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1}",
                //    this.GetType().Name, p.Amount);
            }
            else
            {

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Bölge müdürü - Nazlı Siyah";
                bankProcess.Description = "Müşteriye talep ettiği tutar banka limitlerinin günlük çeki tutarı";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;

                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

              
                
            }
        }
    }
}
