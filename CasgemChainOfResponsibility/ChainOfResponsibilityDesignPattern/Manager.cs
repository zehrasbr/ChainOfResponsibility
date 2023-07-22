using CasgemChainOfResponsibility.DAL;
using CasgemChainOfResponsibility.Models;

namespace CasgemChainOfResponsibility.ChainOfResponsibilityDesignPattern
{
    public class Manager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 200000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Mehmet Sabırlı";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Şube Müdürü Tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Mehmet Sabırlı";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Bölge Müdürüne Yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
