using UpSchool_ChainOfResponsibility.DAL.Entities;
using UpSchool_ChainOfResponsibility.DAL;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 70000)
            {
                
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Müdür Yardımcısı - Hilal Sarı";
                    bankProcess.Description = "Müşteriye talep olmuş olduğu ödemesi şube müdürü yardımcısı tarafından gerçekleştirildi";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                
                //db ye kaydetme işlemi
                //Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1}",
                //    this.GetType().Name, p.Amount);
            }
            else if (NextApprover != null)
            {

                BankProcess bankProcess = new BankProcess();
                bankProcess.EmployeeName = "Müdür Yardımcısı - Hilal Sarı";
                bankProcess.Description = "Müşteriye talep olmuş olduğu ödemesi şube müdürüne tarafından gerçekleştirildi";
                bankProcess.Amount = req.Amount;
                bankProcess.CustomerName = req.CustomerName;

                context.BankProcesses.Add(bankProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

                
            }
        }
    }
}
