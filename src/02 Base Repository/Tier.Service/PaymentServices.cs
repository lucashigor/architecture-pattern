using DBAccess;
using EntityPhoto;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(ICollection<Payment> collection, bool commit)
        {
            foreach (var item in collection)
            {
                Delete(item.Id, commit);
            }
        }

        public void Delete(int id, bool commit)
        {
            _unitOfWork.PaymentRepository.Delete(x => x.Id == id);

            if(commit)
            {
                Commit();
            }
        }

        public ICollection<Payment> Get(int idPaymentPlan)
        {
            return _unitOfWork.PaymentRepository.GetMany(x => x.PaymentPlan_Id == idPaymentPlan).ToList();
        }

        public Payment Get(int id, int idPaymentPlan)
        {
            return _unitOfWork.PaymentRepository.Get(x => x.PaymentPlan_Id == idPaymentPlan && x.Id == id);
        }

        public Payment Post(Payment value)
        {
            return _unitOfWork.PaymentRepository.Create(value);
        }

        public Payment Put(int id, Payment value)
        {
            var payment = _unitOfWork.PaymentRepository.Get(x => x.Id == id);

            if(value.PaidDate != null)
            {
                payment.PaidDate = value.PaidDate;
            }
            if (value.PaidValue != null)
            {
                payment.PaidValue = value.PaidValue;
            }
            if (value.PaymentDate != null)
            {
                payment.PaymentDate = value.PaymentDate;
            }
            if (value.Value != null)
            {
                payment.Value = value.Value;
            }

            _unitOfWork.PaymentRepository.Update(payment);

            return payment;
        }

        private void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
