namespace UpSchool_ChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void ProcessRequest(WithdrawViewModel p);
    }
}
