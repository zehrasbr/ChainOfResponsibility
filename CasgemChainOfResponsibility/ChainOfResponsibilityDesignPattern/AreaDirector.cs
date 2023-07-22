using CasgemChainOfResponsibility.DAL;
using CasgemChainOfResponsibility.Models;

namespace CasgemChainOfResponsibility.ChainOfResponsibilityDesignPattern
{
    public class AreaDirector : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            Context context = new Context();
            if (req.Amount <= 300000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Description = "Müşterinin Talep ettiği tutar Bölge Müdürü Tarafından ödendi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerName = req.CustomerName;
                customerProcess.EmployeeName = "Hakan Bahşiş";
                customerProcess.Description = "Müşterinin Talep ettiği tutar günlük ödemeyi aştığı için işlem gerçekleştirilmedi!";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();

            }
        }
    }
}
