using CasgemChainOfResponsibility.DAL;
using CasgemChainOfResponsibility.Models;

namespace CasgemChainOfResponsibility.ChainOfResponsibilityDesignPattern
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 50000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Sümeyye Sabırlı";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Veznedar tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Sümeyye Sabırlı";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Şube Müdür Yardımcsına yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);

            }
        }
    }
}
