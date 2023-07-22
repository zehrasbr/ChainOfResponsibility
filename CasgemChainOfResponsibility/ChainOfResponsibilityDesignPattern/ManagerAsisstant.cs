using CasgemChainOfResponsibility.DAL;
using CasgemChainOfResponsibility.Models;

namespace CasgemChainOfResponsibility.ChainOfResponsibilityDesignPattern
{
    public class ManagerAsisstant : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "İlayda Özken";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Şube Müdür Yardımcsı Tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "İlayda Özken";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Şube Müdürüne Yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
