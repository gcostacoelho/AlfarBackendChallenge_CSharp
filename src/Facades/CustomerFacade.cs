using AlfarBackendChallengeV2.src.Facades.Interfaces;
using AlfarBackendChallengeV2.src.Models.Customer;
using AlfarBackendChallengeV2.src.Models.Email;
using AlfarBackendChallengeV2.src.Services.Interfaces;
using Newtonsoft.Json;

namespace AlfarBackendChallengeV2.src.Facades
{
    public class CustomerFacade : ICustomerFacade
    {
        private const string SUBJECT = "{0}, conta criada com sucesso";

        private readonly ICustomerService _customer;
        private readonly IMailKitService _mailKit;

        public CustomerFacade(ICustomerService customerService, IMailKitService mailKitService)
        {
            _customer = customerService;
            _mailKit = mailKitService;
        }

        // TODO: Validar se o email é correto antes de salvar no banco
        public async Task<Customer> PostNewCustomerAndSendEmailAsync(Customer customer)
        {
            try
            {
                var customerInDB = await _customer.PostNewCustomer(customer);

                var emailMounted = MountEmail(customerInDB);

                _mailKit.SendEmail(emailMounted);

                return customerInDB;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Internal Server Error");
            }
        }

        private static Email MountEmail(Customer customerData)
        {
            var emailBody = string.Format("Informações que  foram cadaastradas: \n\n {0}", JsonConvert.SerializeObject(customerData));

            return new Email()
            {
                To = customerData.Email,
                Subject = string.Format(SUBJECT, customerData.Name),
                Username = customerData.Name,
                Body = emailBody
            };
        }
    }
}