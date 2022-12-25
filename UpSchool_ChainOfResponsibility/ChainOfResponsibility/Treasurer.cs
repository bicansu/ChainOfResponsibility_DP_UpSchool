using System;
using UpSchool_ChainOfResponsibility.DAL;

namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer: Employee
    {
        public override void ProcessRequest(WithdrawViewModel p)
        {
            if (p.Amount <= 40000)
            {
                using(var context = new Context())
                {
                    p.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    p.Description = "Müşteriye talep olmuş olduğu ödemesi gerçekleştirildi";
                    context.BankProcesses.Add(p);
                }
                //db ye kaydetme işlemi
                //Console.WriteLine("{0} tarafından para çekme işlemi onaylandı #{1}",
                //    this.GetType().Name, p.Amount);
            }
            else if (NextApprover != null)
            {
                Console.WriteLine("{0} TL işlem tutarı {1} max. limitini aştığından işlem yöneticiye gönderildi.", req.Amount, this.GetType().Name);

                NextApprover.ProcessRequest(p);
            }
        }
    }
}
